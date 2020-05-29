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


<Global.System.Data.Linq.Mapping.DatabaseAttribute(Name:="FDA_XML")>  _
Partial Public Class LGT_NCTDataContext
	Inherits System.Data.Linq.DataContext
	
	Private Shared mappingSource As System.Data.Linq.Mapping.MappingSource = New AttributeMappingSource()
	
  #Region "Extensibility Method Definitions"
  Partial Private Sub OnCreated()
  End Sub
  Partial Private Sub InsertXML_NCT(instance As XML_NCT)
    End Sub
  Partial Private Sub UpdateXML_NCT(instance As XML_NCT)
    End Sub
  Partial Private Sub DeleteXML_NCT(instance As XML_NCT)
    End Sub
  #End Region
	
	Public Sub New()
		MyBase.New(Global.System.Configuration.ConfigurationManager.ConnectionStrings("FDA_XMLConnectionString").ConnectionString, mappingSource)
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
	
	Public ReadOnly Property XML_NCTs() As System.Data.Linq.Table(Of XML_NCT)
		Get
			Return Me.GetTable(Of XML_NCT)
		End Get
	End Property
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.XML_NCT")>  _
Partial Public Class XML_NCT
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _pvncd As System.Nullable(Of Short)
	
	Private _lcnno As String
	
	Private _lcnsid As System.Nullable(Of Integer)
	
	Private _rcvno As String
	
	Private _conventpcd2 As String
	
	Private _rgttpcd As String
	
	Private _rid As System.Nullable(Of Integer)
	
	Private _lcntypecd As System.Nullable(Of Integer)
	
	Private _trdnm As String
	
	Private _gennm As String
	
	Private _itemtype As System.Nullable(Of Short)
	
	Private _rcvdate As System.Nullable(Of Date)
	
	Private _expdate As System.Nullable(Of Date)
	
	Private _GroupName As String
	
	Private _NEWCODE As String
	
	Private _Producer_Name As String
	
	Private _Cntcd As String
	
	Private _CreateDate As System.Nullable(Of Date)
	
	Private _UpdateDate As System.Nullable(Of Date)
	
	Private _Ranking As String
	
	Private _convenst As System.Nullable(Of Integer)
	
	Private _IDA As Integer
	
	Private _IDENTIFY As String
	
	Private _frgn_Addr As String
	
	Private _totalqty As String
	
	Private _totaluntcd As String
	
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnpvncdChanging(value As System.Nullable(Of Short))
    End Sub
    Partial Private Sub OnpvncdChanged()
    End Sub
    Partial Private Sub OnlcnnoChanging(value As String)
    End Sub
    Partial Private Sub OnlcnnoChanged()
    End Sub
    Partial Private Sub OnlcnsidChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnlcnsidChanged()
    End Sub
    Partial Private Sub OnrcvnoChanging(value As String)
    End Sub
    Partial Private Sub OnrcvnoChanged()
    End Sub
    Partial Private Sub Onconventpcd2Changing(value As String)
    End Sub
    Partial Private Sub Onconventpcd2Changed()
    End Sub
    Partial Private Sub OnrgttpcdChanging(value As String)
    End Sub
    Partial Private Sub OnrgttpcdChanged()
    End Sub
    Partial Private Sub OnridChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnridChanged()
    End Sub
    Partial Private Sub OnlcntypecdChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnlcntypecdChanged()
    End Sub
    Partial Private Sub OntrdnmChanging(value As String)
    End Sub
    Partial Private Sub OntrdnmChanged()
    End Sub
    Partial Private Sub OngennmChanging(value As String)
    End Sub
    Partial Private Sub OngennmChanged()
    End Sub
    Partial Private Sub OnitemtypeChanging(value As System.Nullable(Of Short))
    End Sub
    Partial Private Sub OnitemtypeChanged()
    End Sub
    Partial Private Sub OnrcvdateChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnrcvdateChanged()
    End Sub
    Partial Private Sub OnexpdateChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnexpdateChanged()
    End Sub
    Partial Private Sub OnGroupNameChanging(value As String)
    End Sub
    Partial Private Sub OnGroupNameChanged()
    End Sub
    Partial Private Sub OnNEWCODEChanging(value As String)
    End Sub
    Partial Private Sub OnNEWCODEChanged()
    End Sub
    Partial Private Sub OnProducer_NameChanging(value As String)
    End Sub
    Partial Private Sub OnProducer_NameChanged()
    End Sub
    Partial Private Sub OnCntcdChanging(value As String)
    End Sub
    Partial Private Sub OnCntcdChanged()
    End Sub
    Partial Private Sub OnCreateDateChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnCreateDateChanged()
    End Sub
    Partial Private Sub OnUpdateDateChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnUpdateDateChanged()
    End Sub
    Partial Private Sub OnRankingChanging(value As String)
    End Sub
    Partial Private Sub OnRankingChanged()
    End Sub
    Partial Private Sub OnconvenstChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnconvenstChanged()
    End Sub
    Partial Private Sub OnIDAChanging(value As Integer)
    End Sub
    Partial Private Sub OnIDAChanged()
    End Sub
    Partial Private Sub OnIDENTIFYChanging(value As String)
    End Sub
    Partial Private Sub OnIDENTIFYChanged()
    End Sub
    Partial Private Sub Onfrgn_AddrChanging(value As String)
    End Sub
    Partial Private Sub Onfrgn_AddrChanged()
    End Sub
    Partial Private Sub OntotalqtyChanging(value As String)
    End Sub
    Partial Private Sub OntotalqtyChanged()
    End Sub
    Partial Private Sub OntotaluntcdChanging(value As String)
    End Sub
    Partial Private Sub OntotaluntcdChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_pvncd", DbType:="SmallInt")>  _
	Public Property pvncd() As System.Nullable(Of Short)
		Get
			Return Me._pvncd
		End Get
		Set
			If (Me._pvncd.Equals(value) = false) Then
				Me.OnpvncdChanging(value)
				Me.SendPropertyChanging
				Me._pvncd = value
				Me.SendPropertyChanged("pvncd")
				Me.OnpvncdChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_lcnno", DbType:="NVarChar(255)")>  _
	Public Property lcnno() As String
		Get
			Return Me._lcnno
		End Get
		Set
			If (String.Equals(Me._lcnno, value) = false) Then
				Me.OnlcnnoChanging(value)
				Me.SendPropertyChanging
				Me._lcnno = value
				Me.SendPropertyChanged("lcnno")
				Me.OnlcnnoChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_lcnsid", DbType:="Int")>  _
	Public Property lcnsid() As System.Nullable(Of Integer)
		Get
			Return Me._lcnsid
		End Get
		Set
			If (Me._lcnsid.Equals(value) = false) Then
				Me.OnlcnsidChanging(value)
				Me.SendPropertyChanging
				Me._lcnsid = value
				Me.SendPropertyChanged("lcnsid")
				Me.OnlcnsidChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_rcvno", DbType:="NVarChar(255)")>  _
	Public Property rcvno() As String
		Get
			Return Me._rcvno
		End Get
		Set
			If (String.Equals(Me._rcvno, value) = false) Then
				Me.OnrcvnoChanging(value)
				Me.SendPropertyChanging
				Me._rcvno = value
				Me.SendPropertyChanged("rcvno")
				Me.OnrcvnoChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_conventpcd2", DbType:="NVarChar(255)")>  _
	Public Property conventpcd2() As String
		Get
			Return Me._conventpcd2
		End Get
		Set
			If (String.Equals(Me._conventpcd2, value) = false) Then
				Me.Onconventpcd2Changing(value)
				Me.SendPropertyChanging
				Me._conventpcd2 = value
				Me.SendPropertyChanged("conventpcd2")
				Me.Onconventpcd2Changed
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_rgttpcd", DbType:="NVarChar(50)")>  _
	Public Property rgttpcd() As String
		Get
			Return Me._rgttpcd
		End Get
		Set
			If (String.Equals(Me._rgttpcd, value) = false) Then
				Me.OnrgttpcdChanging(value)
				Me.SendPropertyChanging
				Me._rgttpcd = value
				Me.SendPropertyChanged("rgttpcd")
				Me.OnrgttpcdChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_rid", DbType:="Int")>  _
	Public Property rid() As System.Nullable(Of Integer)
		Get
			Return Me._rid
		End Get
		Set
			If (Me._rid.Equals(value) = false) Then
				Me.OnridChanging(value)
				Me.SendPropertyChanging
				Me._rid = value
				Me.SendPropertyChanged("rid")
				Me.OnridChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_lcntypecd", DbType:="Int")>  _
	Public Property lcntypecd() As System.Nullable(Of Integer)
		Get
			Return Me._lcntypecd
		End Get
		Set
			If (Me._lcntypecd.Equals(value) = false) Then
				Me.OnlcntypecdChanging(value)
				Me.SendPropertyChanging
				Me._lcntypecd = value
				Me.SendPropertyChanged("lcntypecd")
				Me.OnlcntypecdChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_trdnm", DbType:="VarChar(250)")>  _
	Public Property trdnm() As String
		Get
			Return Me._trdnm
		End Get
		Set
			If (String.Equals(Me._trdnm, value) = false) Then
				Me.OntrdnmChanging(value)
				Me.SendPropertyChanging
				Me._trdnm = value
				Me.SendPropertyChanged("trdnm")
				Me.OntrdnmChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_gennm", DbType:="VarChar(250)")>  _
	Public Property gennm() As String
		Get
			Return Me._gennm
		End Get
		Set
			If (String.Equals(Me._gennm, value) = false) Then
				Me.OngennmChanging(value)
				Me.SendPropertyChanging
				Me._gennm = value
				Me.SendPropertyChanged("gennm")
				Me.OngennmChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_itemtype", DbType:="SmallInt")>  _
	Public Property itemtype() As System.Nullable(Of Short)
		Get
			Return Me._itemtype
		End Get
		Set
			If (Me._itemtype.Equals(value) = false) Then
				Me.OnitemtypeChanging(value)
				Me.SendPropertyChanging
				Me._itemtype = value
				Me.SendPropertyChanged("itemtype")
				Me.OnitemtypeChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_rcvdate", DbType:="Date")>  _
	Public Property rcvdate() As System.Nullable(Of Date)
		Get
			Return Me._rcvdate
		End Get
		Set
			If (Me._rcvdate.Equals(value) = false) Then
				Me.OnrcvdateChanging(value)
				Me.SendPropertyChanging
				Me._rcvdate = value
				Me.SendPropertyChanged("rcvdate")
				Me.OnrcvdateChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_expdate", DbType:="Date")>  _
	Public Property expdate() As System.Nullable(Of Date)
		Get
			Return Me._expdate
		End Get
		Set
			If (Me._expdate.Equals(value) = false) Then
				Me.OnexpdateChanging(value)
				Me.SendPropertyChanging
				Me._expdate = value
				Me.SendPropertyChanged("expdate")
				Me.OnexpdateChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_GroupName", DbType:="NVarChar(50)")>  _
	Public Property GroupName() As String
		Get
			Return Me._GroupName
		End Get
		Set
			If (String.Equals(Me._GroupName, value) = false) Then
				Me.OnGroupNameChanging(value)
				Me.SendPropertyChanging
				Me._GroupName = value
				Me.SendPropertyChanged("GroupName")
				Me.OnGroupNameChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_NEWCODE", DbType:="NVarChar(307)")>  _
	Public Property NEWCODE() As String
		Get
			Return Me._NEWCODE
		End Get
		Set
			If (String.Equals(Me._NEWCODE, value) = false) Then
				Me.OnNEWCODEChanging(value)
				Me.SendPropertyChanging
				Me._NEWCODE = value
				Me.SendPropertyChanged("NEWCODE")
				Me.OnNEWCODEChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Producer_Name", DbType:="NVarChar(MAX)")>  _
	Public Property Producer_Name() As String
		Get
			Return Me._Producer_Name
		End Get
		Set
			If (String.Equals(Me._Producer_Name, value) = false) Then
				Me.OnProducer_NameChanging(value)
				Me.SendPropertyChanging
				Me._Producer_Name = value
				Me.SendPropertyChanged("Producer_Name")
				Me.OnProducer_NameChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Cntcd", DbType:="NVarChar(50)")>  _
	Public Property Cntcd() As String
		Get
			Return Me._Cntcd
		End Get
		Set
			If (String.Equals(Me._Cntcd, value) = false) Then
				Me.OnCntcdChanging(value)
				Me.SendPropertyChanging
				Me._Cntcd = value
				Me.SendPropertyChanged("Cntcd")
				Me.OnCntcdChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_CreateDate", DbType:="DateTime")>  _
	Public Property CreateDate() As System.Nullable(Of Date)
		Get
			Return Me._CreateDate
		End Get
		Set
			If (Me._CreateDate.Equals(value) = false) Then
				Me.OnCreateDateChanging(value)
				Me.SendPropertyChanging
				Me._CreateDate = value
				Me.SendPropertyChanged("CreateDate")
				Me.OnCreateDateChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_UpdateDate", DbType:="DateTime")>  _
	Public Property UpdateDate() As System.Nullable(Of Date)
		Get
			Return Me._UpdateDate
		End Get
		Set
			If (Me._UpdateDate.Equals(value) = false) Then
				Me.OnUpdateDateChanging(value)
				Me.SendPropertyChanging
				Me._UpdateDate = value
				Me.SendPropertyChanged("UpdateDate")
				Me.OnUpdateDateChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Ranking", DbType:="NVarChar(50)")>  _
	Public Property Ranking() As String
		Get
			Return Me._Ranking
		End Get
		Set
			If (String.Equals(Me._Ranking, value) = false) Then
				Me.OnRankingChanging(value)
				Me.SendPropertyChanging
				Me._Ranking = value
				Me.SendPropertyChanged("Ranking")
				Me.OnRankingChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_convenst", DbType:="Int")>  _
	Public Property convenst() As System.Nullable(Of Integer)
		Get
			Return Me._convenst
		End Get
		Set
			If (Me._convenst.Equals(value) = false) Then
				Me.OnconvenstChanging(value)
				Me.SendPropertyChanging
				Me._convenst = value
				Me.SendPropertyChanged("convenst")
				Me.OnconvenstChanged
			End If
		End Set
	End Property
	
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
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IDENTIFY", DbType:="NVarChar(MAX)")>  _
	Public Property IDENTIFY() As String
		Get
			Return Me._IDENTIFY
		End Get
		Set
			If (String.Equals(Me._IDENTIFY, value) = false) Then
				Me.OnIDENTIFYChanging(value)
				Me.SendPropertyChanging
				Me._IDENTIFY = value
				Me.SendPropertyChanged("IDENTIFY")
				Me.OnIDENTIFYChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_frgn_Addr", DbType:="NVarChar(MAX)")>  _
	Public Property frgn_Addr() As String
		Get
			Return Me._frgn_Addr
		End Get
		Set
			If (String.Equals(Me._frgn_Addr, value) = false) Then
				Me.Onfrgn_AddrChanging(value)
				Me.SendPropertyChanging
				Me._frgn_Addr = value
				Me.SendPropertyChanged("frgn_Addr")
				Me.Onfrgn_AddrChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_totalqty", DbType:="NVarChar(50)")>  _
	Public Property totalqty() As String
		Get
			Return Me._totalqty
		End Get
		Set
			If (String.Equals(Me._totalqty, value) = false) Then
				Me.OntotalqtyChanging(value)
				Me.SendPropertyChanging
				Me._totalqty = value
				Me.SendPropertyChanged("totalqty")
				Me.OntotalqtyChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_totaluntcd", DbType:="NVarChar(50)")>  _
	Public Property totaluntcd() As String
		Get
			Return Me._totaluntcd
		End Get
		Set
			If (String.Equals(Me._totaluntcd, value) = false) Then
				Me.OntotaluntcdChanging(value)
				Me.SendPropertyChanging
				Me._totaluntcd = value
				Me.SendPropertyChanged("totaluntcd")
				Me.OntotaluntcdChanged
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
