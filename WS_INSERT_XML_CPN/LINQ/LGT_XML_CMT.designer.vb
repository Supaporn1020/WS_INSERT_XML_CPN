﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Reflection


<Global.System.Data.Linq.Mapping.DatabaseAttribute(Name:="FDA_XML_CMT")>  _
Partial Public Class LGT_XML_CMTDataContext
	Inherits System.Data.Linq.DataContext
	
	Private Shared mappingSource As System.Data.Linq.Mapping.MappingSource = New AttributeMappingSource()
	
  #Region "Extensibility Method Definitions"
  Partial Private Sub OnCreated()
  End Sub
  Partial Private Sub InsertLICENSE_HISTORY_CMT(instance As LICENSE_HISTORY_CMT)
    End Sub
  Partial Private Sub UpdateLICENSE_HISTORY_CMT(instance As LICENSE_HISTORY_CMT)
    End Sub
  Partial Private Sub DeleteLICENSE_HISTORY_CMT(instance As LICENSE_HISTORY_CMT)
    End Sub
  #End Region
	
	Public Sub New()
		MyBase.New(Global.System.Configuration.ConfigurationManager.ConnectionStrings("FDA_XML_CMTConnectionString").ConnectionString, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public ReadOnly Property LICENSE_HISTORY_CMTs() As System.Data.Linq.Table(Of LICENSE_HISTORY_CMT)
		Get
			Return Me.GetTable(Of LICENSE_HISTORY_CMT)
		End Get
	End Property
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.LICENSE_HISTORY")>  _
Partial Public Class LICENSE_HISTORY_CMT
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _IDA As Integer
	
	Private _APPVDATE As System.Nullable(Of Date)
	
	Private _LCTNO As String
	
	Private _LCNNO As String
	
	Private _TYPE As String
	
	Private _TOPIC As String
	
	Private _TEXT_OLD As String
	
	Private _TEXT_NEW As String
	
	Private _RCVNO As String
	
	Private _RCVDATE As System.Nullable(Of Date)
	
	Private _DESCRIPTION As String
	
	Private _REF_NO As String
	
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnIDAChanging(value As Integer)
    End Sub
    Partial Private Sub OnIDAChanged()
    End Sub
    Partial Private Sub OnAPPVDATEChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnAPPVDATEChanged()
    End Sub
    Partial Private Sub OnLCTNOChanging(value As String)
    End Sub
    Partial Private Sub OnLCTNOChanged()
    End Sub
    Partial Private Sub OnLCNNOChanging(value As String)
    End Sub
    Partial Private Sub OnLCNNOChanged()
    End Sub
    Partial Private Sub OnTYPEChanging(value As String)
    End Sub
    Partial Private Sub OnTYPEChanged()
    End Sub
    Partial Private Sub OnTOPICChanging(value As String)
    End Sub
    Partial Private Sub OnTOPICChanged()
    End Sub
    Partial Private Sub OnTEXT_OLDChanging(value As String)
    End Sub
    Partial Private Sub OnTEXT_OLDChanged()
    End Sub
    Partial Private Sub OnTEXT_NEWChanging(value As String)
    End Sub
    Partial Private Sub OnTEXT_NEWChanged()
    End Sub
    Partial Private Sub OnRCVNOChanging(value As String)
    End Sub
    Partial Private Sub OnRCVNOChanged()
    End Sub
    Partial Private Sub OnRCVDATEChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnRCVDATEChanged()
    End Sub
    Partial Private Sub OnDESCRIPTIONChanging(value As String)
    End Sub
    Partial Private Sub OnDESCRIPTIONChanged()
    End Sub
    Partial Private Sub OnREF_NOChanging(value As String)
    End Sub
    Partial Private Sub OnREF_NOChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IDA", AutoSync:=AutoSync.OnInsert, DbType:="Int NOT NULL IDENTITY", IsPrimaryKey:=true, IsDbGenerated:=true)>  _
	Public Property IDA() As Integer
		Get
			Return Me._IDA
		End Get
		Set
			If ((Me._IDA = value)  _
						= false) Then
				Me.OnIDAChanging(value)
				Me.SendPropertyChanging
				Me._IDA = value
				Me.SendPropertyChanged("IDA")
				Me.OnIDAChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_APPVDATE", DbType:="DateTime")>  _
	Public Property APPVDATE() As System.Nullable(Of Date)
		Get
			Return Me._APPVDATE
		End Get
		Set
			If (Me._APPVDATE.Equals(value) = false) Then
				Me.OnAPPVDATEChanging(value)
				Me.SendPropertyChanging
				Me._APPVDATE = value
				Me.SendPropertyChanged("APPVDATE")
				Me.OnAPPVDATEChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_LCTNO", DbType:="NVarChar(50)")>  _
	Public Property LCTNO() As String
		Get
			Return Me._LCTNO
		End Get
		Set
			If (String.Equals(Me._LCTNO, value) = false) Then
				Me.OnLCTNOChanging(value)
				Me.SendPropertyChanging
				Me._LCTNO = value
				Me.SendPropertyChanged("LCTNO")
				Me.OnLCTNOChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_LCNNO", DbType:="NVarChar(50)")>  _
	Public Property LCNNO() As String
		Get
			Return Me._LCNNO
		End Get
		Set
			If (String.Equals(Me._LCNNO, value) = false) Then
				Me.OnLCNNOChanging(value)
				Me.SendPropertyChanging
				Me._LCNNO = value
				Me.SendPropertyChanged("LCNNO")
				Me.OnLCNNOChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_TYPE", DbType:="NVarChar(100)")>  _
	Public Property TYPE() As String
		Get
			Return Me._TYPE
		End Get
		Set
			If (String.Equals(Me._TYPE, value) = false) Then
				Me.OnTYPEChanging(value)
				Me.SendPropertyChanging
				Me._TYPE = value
				Me.SendPropertyChanged("TYPE")
				Me.OnTYPEChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_TOPIC", DbType:="NVarChar(MAX)")>  _
	Public Property TOPIC() As String
		Get
			Return Me._TOPIC
		End Get
		Set
			If (String.Equals(Me._TOPIC, value) = false) Then
				Me.OnTOPICChanging(value)
				Me.SendPropertyChanging
				Me._TOPIC = value
				Me.SendPropertyChanged("TOPIC")
				Me.OnTOPICChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_TEXT_OLD", DbType:="NVarChar(MAX)")>  _
	Public Property TEXT_OLD() As String
		Get
			Return Me._TEXT_OLD
		End Get
		Set
			If (String.Equals(Me._TEXT_OLD, value) = false) Then
				Me.OnTEXT_OLDChanging(value)
				Me.SendPropertyChanging
				Me._TEXT_OLD = value
				Me.SendPropertyChanged("TEXT_OLD")
				Me.OnTEXT_OLDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_TEXT_NEW", DbType:="NVarChar(MAX)")>  _
	Public Property TEXT_NEW() As String
		Get
			Return Me._TEXT_NEW
		End Get
		Set
			If (String.Equals(Me._TEXT_NEW, value) = false) Then
				Me.OnTEXT_NEWChanging(value)
				Me.SendPropertyChanging
				Me._TEXT_NEW = value
				Me.SendPropertyChanged("TEXT_NEW")
				Me.OnTEXT_NEWChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_RCVNO", DbType:="NVarChar(50)")>  _
	Public Property RCVNO() As String
		Get
			Return Me._RCVNO
		End Get
		Set
			If (String.Equals(Me._RCVNO, value) = false) Then
				Me.OnRCVNOChanging(value)
				Me.SendPropertyChanging
				Me._RCVNO = value
				Me.SendPropertyChanged("RCVNO")
				Me.OnRCVNOChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_RCVDATE", DbType:="DateTime")>  _
	Public Property RCVDATE() As System.Nullable(Of Date)
		Get
			Return Me._RCVDATE
		End Get
		Set
			If (Me._RCVDATE.Equals(value) = false) Then
				Me.OnRCVDATEChanging(value)
				Me.SendPropertyChanging
				Me._RCVDATE = value
				Me.SendPropertyChanged("RCVDATE")
				Me.OnRCVDATEChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_DESCRIPTION", DbType:="NVarChar(MAX)")>  _
	Public Property DESCRIPTION() As String
		Get
			Return Me._DESCRIPTION
		End Get
		Set
			If (String.Equals(Me._DESCRIPTION, value) = false) Then
				Me.OnDESCRIPTIONChanging(value)
				Me.SendPropertyChanging
				Me._DESCRIPTION = value
				Me.SendPropertyChanged("DESCRIPTION")
				Me.OnDESCRIPTIONChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_REF_NO", DbType:="NVarChar(80)")>  _
	Public Property REF_NO() As String
		Get
			Return Me._REF_NO
		End Get
		Set
			If (String.Equals(Me._REF_NO, value) = false) Then
				Me.OnREF_NOChanging(value)
				Me.SendPropertyChanging
				Me._REF_NO = value
				Me.SendPropertyChanged("REF_NO")
				Me.OnREF_NOChanged
			End If
		End Set
	End Property
	
	Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
	
	Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
	
	Protected Overridable Sub SendPropertyChanging()
		If ((Me.PropertyChangingEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
		End If
	End Sub
	
	Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
		If ((Me.PropertyChangedEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End If
	End Sub
End Class
