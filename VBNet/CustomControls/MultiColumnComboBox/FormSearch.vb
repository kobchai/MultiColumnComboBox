Option Explicit On
Option Strict On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Public Class FormSearch

#Region "Attributes"
    'MultiColumnComboBox _ComboBox
    Dim _ComboBox As MultiColumnComboBox

    '    int _Column = 0
    Dim _Column As Integer = 0
    '    int _Row = 0
    Dim _Row As Integer = 0
#End Region

#Region "Construction and Destruction"
    '    public FormSearch(MultiColumnComboBox comboBox)
    '    {
    '        InitializeComponent()
    '        _ComboBox = comboBox
    '        Init()
    '    }
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Sub New(comboBox As MultiColumnComboBox)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        _ComboBox = comboBox
        Init()
    End Sub
#End Region

#Region "Sub, Functions"
    'private void Init()
    '{
    '    //Set the datasource of the grid = datasource of the combobox
    '    dataGridView1.DataSource = _ComboBox.DataSource
    '    txtStatus.Text = ""

    '    //Set all the columns invisible
    '    for (int idx = 0 idx < dataGridView1.Columns.Count idx++)
    '    {
    '        dataGridView1.Columns[idx].Visible = false
    '    }

    '    //Iterate through the ColumnNameCollection. If a column isn't listed
    '    //don't set it to visible. If a column's width is zero, don't set it to
    '    //visible. Set it's DisplayIndex equal to it's index in the collection.
    '    for (int idx = 0 idx < _ComboBox.ColumnNameCollection.Count idx++)
    '    {
    '        dataGridView1.Columns[_ComboBox.ColumnNameCollection[idx]].DisplayIndex = idx
    '        dataGridView1.Columns[_ComboBox.ColumnNameCollection[idx]].Visible =
    '                                _ComboBox.ColumnWidthCollection[idx] > 0 ? true : false
    '    }
    '}
    Private Sub Init()
        ' Set the datasource of the grid = datasource of the combobox
        DataGridView1.DataSource = _ComboBox.DataSource
        txtStatus.Text = ""

        ' Set all the columns invisible
        For idx As Integer = 0 To DataGridView1.Columns.Count - 1
            DataGridView1.Columns(idx).Visible = False
        Next

        ' Iterate through the ColumnNameCollection. If a column isn't listed
        ' don't set it to visible. If a column's width is zero, don't set it to
        ' visible. Set it's DisplayIndex equal to it's index in the collection.
        'for (int idx = 0 idx < _ComboBox.ColumnNameCollection.Count idx++)
        For idx As Integer = 0 To _ComboBox.ColumnNameCollection.Count - 1
            DataGridView1.Columns(_ComboBox.ColumnNameCollection(idx)).DisplayIndex = idx
            DataGridView1.Columns(_ComboBox.ColumnNameCollection(idx)).Visible = If(_ComboBox.ColumnWidthCollection(idx) > 0, True, False)
        Next

        'AddHandler txtSearch.KeyDown, AddressOf txtSearch_KeyDown
        'AddHandler dataGridView1.DoubleClick, AddressOf dataGridView1_DoubleClick
    End Sub

    'private void dataGridView1_DoubleClick(object sender, EventArgs e)
    '{
    '    //Set the SelectedIndex of the combobox to the index 
    '    //if the double-clicked grid row
    '    _ComboBox.SelectedIndex = dataGridView1.CurrentRow.Index
    '    this.Close()
    '}
    Private Sub dataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        ' Set the SelectedIndex of the combobox to the index
        ' if the double-clicked grid row
        _ComboBox.SelectedIndex = DataGridView1.CurrentRow.Index
        Me.Close()
    End Sub

    'private void txtSearch_KeyDown(object sender, KeyEventArgs e)
    '{
    '    //If the user hits the <Enter> key, peform a search
    '    if (e.KeyCode == Keys.Enter)
    '    {
    '        SearchGrid();
    '    }
    '}
    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        ' If the user hits the <Enter> key, peform a search
        If (e.KeyCode.Equals(Keys.Enter)) Then
            SearchGrid()
        End If
    End Sub

    'private void SearchGrid()
    '{
    '    //maxSearches = the # of cells in the grid
    '    int maxSearches = dataGridView1.Rows.Count * dataGridView1.Columns.Count + 1;
    '    int idx = 1;
    '    bool isFound = false;
    '    string searchValue = txtSearch.Text.ToUpper();

    '    if (Convert.ToBoolean(txtSearch.Text.Length))
    '    {
    '        // If the item is not found and you haven't looked at every cell, keep searching
    '        while ((!isFound) & (idx < maxSearches))
    '        {
    '            // Only search visible cells
    '            if (dataGridView1.Columns[_Column].Visible)
    '            {
    '                // Do all comparing in UpperCase so it is case insensitive
    '                if (dataGridView1[_Column, _Row].Value.ToString().ToUpper().Contains(searchValue))
    '                {
    '                    // If found position on the item
    '                    dataGridView1.FirstDisplayedScrollingRowIndex = _Row;
    '                    dataGridView1[_Column, _Row].Selected = true;
    '                    isFound = true;
    '                    txtStatus.Text = "Search phrase found!";
    '                }
    '            }

    '            // Increment the column.
    '            _Column++;

    '            // If it exceeds the column count
    '            if (_Column == dataGridView1.Columns.Count)
    '            {
    '                _Column = 0; //Go to 0 column
    '                _Row++;      //Go to the next row

    '                // If it exceeds the row count
    '                if (_Row == dataGridView1.Rows.Count)
    '                {
    '                    _Row = 0; //Start over at the top
    '                }
    '            }

    '            idx++;
    '        }

    '        // If isFound = false then the phrase has not been found in the grid
    '        if (! isFound)
    '        {
    '            txtStatus.Text = "Search phrase not found!";
    '        }
    '    }
    '}
    Private Sub SearchGrid()
        'maxSearches = the # of cells in the grid
        Dim maxSearches As Integer = DataGridView1.Rows.Count * DataGridView1.Columns.Count + 1
        Dim idx As Integer = 1
        Dim isFound As Boolean = False
        Dim searchValue As String = txtSearch.Text.ToUpper()

        If (Convert.ToBoolean(txtSearch.Text.Length)) Then
            ' If the item is not found and you haven't looked at every cell, keep searching
            While ((Not isFound) And (idx < maxSearches))
                ' Only search visible cells
                If (DataGridView1.Columns(_Column).Visible) Then
                    ' Do all comparing in UpperCase so it is case insensitive
                    If (DataGridView1(_Column, _Row).Value.ToString().ToUpper().Contains(searchValue)) Then
                        ' If found position on the item
                        DataGridView1.FirstDisplayedScrollingRowIndex = _Row
                        DataGridView1(_Column, _Row).Selected = True
                        isFound = True
                        txtStatus.Text = "Search phrase found!"
                    End If
                End If 'End If (dataGridView1.Columns(_Column).Visible)

                ' Increment the column.
                _Column = _Column + 1


                ' If it exceeds the column count
                If (_Column = DataGridView1.Columns.Count) Then
                    _Column = 0 'Go to 0 column
                    _Row = _Row + 1      'Go to the next row

                    ' If it exceeds the row count
                    If (_Row = DataGridView1.Rows.Count) Then
                        _Row = 0 'Start over at the top
                    End If
                End If

                idx = idx + 1
            End While
        End If 'End If (Convert.ToBoolean(txtSearch.Text.Length))

        ' If isFound = false then the phrase has not been found in the grid
        If (Not isFound) Then
            txtStatus.Text = "Search phrase not found!"
        End If

    End Sub

#End Region


End Class