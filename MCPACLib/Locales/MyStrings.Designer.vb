﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Этот код создан программой.
'     Исполняемая версия:4.0.30319.42000
'
'     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
'     повторной генерации кода.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'Этот класс создан автоматически классом StronglyTypedResourceBuilder
    'с помощью такого средства, как ResGen или Visual Studio.
    'Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    'с параметром /str или перестройте свой проект VS.
    '''<summary>
    '''  Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Public Class MyStrings
        
        Private Shared resourceMan As Global.System.Resources.ResourceManager
        
        Private Shared resourceCulture As Global.System.Globalization.CultureInfo
        
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
        Friend Sub New()
            MyBase.New
        End Sub
        
        '''<summary>
        '''  Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Public Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("MCPixelArtCrafterWPF.MyStrings", GetType(MyStrings).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Перезаписывает свойство CurrentUICulture текущего потока для всех
        '''  обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Public Shared Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Cancel.
        '''</summary>
        Public Shared ReadOnly Property B_Cancel() As String
            Get
                Return ResourceManager.GetString("B_Cancel", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Create image.
        '''</summary>
        Public Shared ReadOnly Property B_CreateImage() As String
            Get
                Return ResourceManager.GetString("B_CreateImage", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Create image.
        '''</summary>
        Public Shared ReadOnly Property B_GenerateImage() As String
            Get
                Return ResourceManager.GetString("B_GenerateImage", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Save.
        '''</summary>
        Public Shared ReadOnly Property B_Save() As String
            Get
                Return ResourceManager.GetString("B_Save", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Select image.
        '''</summary>
        Public Shared ReadOnly Property B_SelectImage() As String
            Get
                Return ResourceManager.GetString("B_SelectImage", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Settings.
        '''</summary>
        Public Shared ReadOnly Property B_Settings() As String
            Get
                Return ResourceManager.GetString("B_Settings", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Map Colors.
        '''</summary>
        Public Shared ReadOnly Property T_Colors() As String
            Get
                Return ResourceManager.GetString("T_Colors", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Textures.
        '''</summary>
        Public Shared ReadOnly Property T_Textures() As String
            Get
                Return ResourceManager.GetString("T_Textures", resourceCulture)
            End Get
        End Property
    End Class
End Namespace
