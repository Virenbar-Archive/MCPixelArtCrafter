Imports Microsoft.WindowsAPICodePack.Taskbar

Public Class StatusHelper

    Public Event Tick()

    Private WithEvents Timer As New Timer
    Private SW As New Stopwatch
    Private frame = 0 : Private ReadOnly Frames As Char() = {"|", "/", "-", "\"}
    Public Property Amount As Integer = 0
    Public Property Count As Integer = 0
    ReadOnly Property IsActive As Boolean = False

    ReadOnly Property Progress As String
        Get
            Return $"Progress: {Format(Count, "N0") }\{Format(Amount, "N0")} ({Format(Count / Amount, "P")})"
        End Get
    End Property

    ReadOnly Property NextFrame As Char
        Get
            frame = (frame + 1) Mod Frames.Length
            Return Frames(frame)
        End Get
    End Property

    ReadOnly Property Elapsed As String
        Get
            Return $"Elapsed: {Format(SW.Elapsed.TotalSeconds, "N1")} s"
        End Get
    End Property

    Public Sub New(interval As Integer)
        Timer.Interval = interval
    End Sub

    Public Sub Start()
        _IsActive = True
        TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal)
        Timer.Start()
        SW.Restart()
    End Sub

    Public Sub Cancel()
        _IsActive = False
        TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Paused)
        Timer.Stop()
        SW.Stop()
    End Sub

    Public Sub [Stop]()
        _IsActive = False
        TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress)
        Timer.Stop()
        SW.Stop()
    End Sub

    Private Sub OnTick() Handles Timer.Tick
        TaskbarManager.Instance.SetProgressValue(Count, Amount)
        RaiseEvent Tick()
    End Sub

End Class