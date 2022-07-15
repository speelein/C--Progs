VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "Betrag"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

Private mdblEuro As Double
Private mdblDM As Double

Public Function GetEuro() As Double
    GetEuro = mdblEuro
End Function

Public Function GetDM() As Double
    GetDM = mdblDM
End Function

Public Function SetEuro(ByVal wert As Double)
    mdblEuro = wert
    mdblDM = wert * 1.95583
End Function

Public Function SetDM(ByVal wert As Double)
    mdblDM = wert
    mdblEuro = wert / 1.95583
End Function

Private Sub Class_Initialize()
    mdblEuro = 0
    mdblDM = 0
End Sub
