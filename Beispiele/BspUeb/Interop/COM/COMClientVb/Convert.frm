VERSION 5.00
Begin VB.Form Convert 
   Caption         =   "Euro-Konverter"
   ClientHeight    =   2340
   ClientLeft      =   3255
   ClientTop       =   2040
   ClientWidth     =   3390
   LinkTopic       =   "Form1"
   ScaleHeight     =   2340
   ScaleWidth      =   3390
   Begin VB.CommandButton Umrechnen 
      Caption         =   "Umrechnen!"
      Height          =   495
      Left            =   240
      TabIndex        =   1
      Top             =   1680
      Width           =   2895
   End
   Begin VB.TextBox euro 
      Height          =   285
      Left            =   1320
      TabIndex        =   0
      Top             =   345
      Width           =   1815
   End
   Begin VB.Label LabelEuro 
      Caption         =   "DM-Betrag:"
      Height          =   255
      Left            =   75
      TabIndex        =   4
      Top             =   1080
      Width           =   1095
   End
   Begin VB.Label LabelErgebnis 
      Height          =   255
      Left            =   1320
      TabIndex        =   3
      Top             =   1080
      Width           =   1815
   End
   Begin VB.Label LabelDM 
      Caption         =   "Euro-Betrag:"
      Height          =   255
      Left            =   75
      TabIndex        =   2
      Top             =   390
      Width           =   975
   End
End
Attribute VB_Name = "Convert"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub Umrechnen_Click()
    Dim b As New EuroKonverter.Betrag
    b.SetEuro euro.Text
    LabelErgebnis.Caption = b.GetDM
End Sub
