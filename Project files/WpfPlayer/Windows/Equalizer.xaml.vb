﻿Imports System.ComponentModel

Public Class Equalizer
    Private Property UpdateEQ As Boolean = True
    Private Sub Eq1_ValueChanged(sender As Object, e As RoutedPropertyChangedEventArgs(Of Double)) Handles Eq1.ValueChanged
        If UpdateEQ Then CType(Owner, MainWindow).MainPlayer.UpdateEQ(0, e.NewValue)
    End Sub
    Private Sub Eq2_ValueChanged(sender As Object, e As RoutedPropertyChangedEventArgs(Of Double)) Handles Eq2.ValueChanged
        If UpdateEQ Then CType(Owner, MainWindow).MainPlayer.UpdateEQ(1, e.NewValue)
    End Sub
    Private Sub Eq3_ValueChanged(sender As Object, e As RoutedPropertyChangedEventArgs(Of Double)) Handles Eq3.ValueChanged
        If UpdateEQ Then CType(Owner, MainWindow).MainPlayer.UpdateEQ(2, e.NewValue)
    End Sub
    Private Sub Eq4_ValueChanged(sender As Object, e As RoutedPropertyChangedEventArgs(Of Double)) Handles Eq4.ValueChanged
        If UpdateEQ Then CType(Owner, MainWindow).MainPlayer.UpdateEQ(3, e.NewValue)
    End Sub
    Private Sub Eq5_ValueChanged(sender As Object, e As RoutedPropertyChangedEventArgs(Of Double)) Handles Eq5.ValueChanged
        If UpdateEQ Then CType(Owner, MainWindow).MainPlayer.UpdateEQ(4, e.NewValue)
    End Sub
    Private Sub Eq6_ValueChanged(sender As Object, e As RoutedPropertyChangedEventArgs(Of Double)) Handles Eq6.ValueChanged
        If UpdateEQ Then CType(Owner, MainWindow).MainPlayer.UpdateEQ(5, e.NewValue)
    End Sub
    Private Sub Eq7_ValueChanged(sender As Object, e As RoutedPropertyChangedEventArgs(Of Double)) Handles Eq7.ValueChanged
        If UpdateEQ Then CType(Owner, MainWindow).MainPlayer.UpdateEQ(6, e.NewValue)
    End Sub
    Private Sub Eq8_ValueChanged(sender As Object, e As RoutedPropertyChangedEventArgs(Of Double)) Handles Eq8.ValueChanged
        If UpdateEQ Then CType(Owner, MainWindow).MainPlayer.UpdateEQ(7, e.NewValue)
    End Sub
    Private Sub Eq9_ValueChanged(sender As Object, e As RoutedPropertyChangedEventArgs(Of Double)) Handles Eq9.ValueChanged
        If UpdateEQ Then CType(Owner, MainWindow).MainPlayer.UpdateEQ(8, e.NewValue)
    End Sub
    Private Sub Eq10_ValueChanged(sender As Object, e As RoutedPropertyChangedEventArgs(Of Double)) Handles Eq10.ValueChanged
        If UpdateEQ Then CType(Owner, MainWindow).MainPlayer.UpdateEQ(9, e.NewValue)
    End Sub
    Private Sub Equalizer_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
        Me.Hide()
    End Sub

    Private Sub ExitBtn_Click(sender As Object, e As RoutedEventArgs) Handles ExitBtn.Click
        Me.Close()
    End Sub

    Public Sub SetPreset(Band0Gain As Integer, Band1Gain As Integer, Band2Gain As Integer, Band3Gain As Integer, Band4Gain As Integer, Band5Gain As Integer, Band6Gain As Integer, Band7Gain As Integer, Band8Gain As Integer, Band9Gain As Integer)
        Eq1.Value = Band0Gain
        Eq2.Value = Band1Gain
        Eq3.Value = Band2Gain
        Eq4.Value = Band3Gain
        Eq5.Value = Band4Gain
        Eq6.Value = Band5Gain
        Eq7.Value = Band6Gain
        Eq8.Value = Band7Gain
        Eq9.Value = Band8Gain
        Eq10.Value = Band9Gain
    End Sub
    Private Sub fx_state_Unchecked(sender As Object, e As RoutedEventArgs) Handles fx_state.Unchecked
        Eq1.Value = 0
        Eq2.Value = 0
        Eq3.Value = 0
        Eq4.Value = 0
        Eq5.Value = 0
        Eq6.Value = 0
        Eq7.Value = 0
        Eq8.Value = 0
        Eq9.Value = 0
        Eq10.Value = 0
        CType(Owner, MainWindow).MainPlayer.UpdateEQ(0, 0, True)
    End Sub

    Private Sub OnEqChanged(EQgains As Integer())
        UpdateEQ = False
        Eq1.Value = EQgains(1)
        Eq2.Value = EQgains(2)
        Eq3.Value = EQgains(3)
        Eq4.Value = EQgains(4)
        Eq5.Value = EQgains(5)
        Eq6.Value = EQgains(6)
        Eq7.Value = EQgains(7)
        Eq8.Value = EQgains(8)
        Eq9.Value = EQgains(9)
        UpdateEQ = True
    End Sub

    Private Sub Equalizer_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        AddHandler TryCast(Application.Current.MainWindow, MainWindow).MainPlayer.OnEqChanged, AddressOf OnEqChanged
    End Sub

    Private Sub Presets_CB_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles Presets_CB.SelectionChanged
        Select Case Presets_CB.SelectedIndex
            Case 2 'Bass Boost Pro
                SetPreset(4, 2, 1, 0, -1, -2, 0, 2, 3, 4)
            Case 4 'Bass Boost Lite
                SetPreset(6, 2, 2, 1, -6, -4, -3, 0, 5, 0)
            Case 3 'Bass Boost +
                SetPreset(15, -8, -8, -10, -10, -6, -3, -1, 0, -1)
            Case 5 'Acoustic
                SetPreset(6, 5, 4, 1, 2, 2, 4, 5, 3, 1)
            Case 6 'Electronic
                SetPreset(4, 4, 1, 0, -2, 3, 1, 1, 4, 5)
            Case 7 'Piano
                SetPreset(3, 2, 0, 3, 3, 1, 4, 5, 3, 3)
            Case 8 'Pop
                SetPreset(-2, -1, 0, 2, 4, 4, 2, 0, -1, -1)
            Case 9 'Rock
                SetPreset(5, 4, 3, 1, 0, -1, 0, 3, 4, 5)
            Case 1 'Super Bass Boost
                SetPreset(6, 5, 4, 3, 1, 0, 0, 0, 0, 0)
            Case 0 'Ultra Bass Boost
                SetPreset(15, 0, -7, -12, -10, -8, -6, -5, -4, -4)
        End Select
    End Sub
End Class
