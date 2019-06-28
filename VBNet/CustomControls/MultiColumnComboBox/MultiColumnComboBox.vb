Option Explicit On
Option Strict On

Imports System
Imports System.Windows.Forms
Imports System.Collections
Imports System.Collections.ObjectModel
'Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization


'Namespace CustomControls

Public Class MultiColumnComboBox : Inherits ComboBox

#Region "Attributes"
    'private bool     _AutoComplete;
    Private _AutoComplete As Boolean
    'private bool     _AutoDropdown;
    Private _AutoDropdown As Boolean
    'private Color    _BackColorEven = Color.White;
    Private _BackColorEven As Color = Color.White
    'private Color    _BackColorOdd = Color.White;
    Private _BackColorOdd As Color = Color.White
    'private string   _ColumnNameString = "";
    Private _ColumnNameString As String = String.Empty
    'private int      _ColumnWidthDefault = 75;
    Private _ColumnWidthDefault As Integer = 75
    'private string   _ColumnWidthString = "";
    Private _ColumnWidthString As String = String.Empty

    'private int      _LinkedColumnIndex;
    Private _LinkedColumnIndex1 As Integer
    'private TextBox  _LinkedTextBox;
    Private _LinkedTextBox1 As TextBox

    Private _LinkedColumnIndex2 As Integer
    Private _LinkedTextBox2 As TextBox

    Private _LinkedColumnIndex3 As Integer
    Private _LinkedTextBox3 As TextBox

    'private int      _TotalWidth = 0;
    Private _TotalWidth As Integer = 0
    'private int      _ValueMemberColumnIndex = 0;
    Private _ValueMemberColumnIndex As Integer = 0

    'private Collection<string> _ColumnNames  = new Collection<string>();
    Private _ColumnNames As Collection(Of String) = New Collection(Of String)()
    'private Collection<int>    _ColumnWidths = new Collection<int>();
    Private _ColumnWidths As Collection(Of Integer) = New Collection(Of Integer)()
#End Region

#Region "Construction and Destruction"
    Public Sub New()
        DrawMode = DrawMode.OwnerDrawVariable
        'Me.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed

        '' If all of your boxes will be RightToLeft, uncomment 
        '' the following line to make RTL the default.
        '' RightToLeft = RightToLeft.Yes;

        '' Remove the Context Menu to disable pasting 
        ContextMenu = New ContextMenu()
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then MyBase.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

#Region "Event handlers"
    'public event System.EventHandler OpenSearchForm;
    Public Event OpenSearchForm As EventHandler
#End Region

#Region "Properties"
    'public bool AutoComplete
    '{
    '    get
    '    {
    '        return _AutoComplete;
    '    }
    '    set
    '    {
    '        _AutoComplete = value;
    '    }
    '}
    Public Property AutoComplete As Boolean
        Get
            Return _AutoComplete
        End Get
        Set(value As Boolean)
            _AutoComplete = value
        End Set
    End Property

    'public bool AutoDropdown
    '{
    '    get
    '    {
    '        return _AutoDropdown;
    '    }
    '    set
    '    {
    '        _AutoDropdown = value;
    '    }
    '}
    Public Property AutoDropdown As Boolean
        Get
            Return _AutoDropdown
        End Get
        Set(value As Boolean)
            _AutoDropdown = value
        End Set
    End Property

    'public Color BackColorEven
    '{
    '    get
    '    {
    '        return _BackColorEven;
    '    }
    '    set
    '    {
    '        _BackColorEven = value;
    '    }
    '}
    Public Property BackColorEven As Color
        Get
            Return _BackColorEven
        End Get
        Set(value As Color)
            _BackColorEven = value
        End Set
    End Property

    'public Color BackColorOdd
    '{
    '    get
    '    {
    '        return _BackColorOdd;
    '    }
    '    set
    '    {
    '        _BackColorOdd = value;
    '    }
    '}
    Public Property BackColorOdd As Color
        Get
            Return _BackColorOdd
        End Get
        Set(value As Color)
            _BackColorOdd = value
        End Set
    End Property

    'public Collection<string> ColumnNameCollection
    '{
    '    get
    '    {
    '        return _ColumnNames;
    '    }
    '}
    Public ReadOnly Property ColumnNameCollection As Collection(Of String)
        Get
            Return _ColumnNames
        End Get
    End Property

    'public string ColumnNames
    '{
    '    get
    '    {
    '        return _ColumnNameString;
    '    }

    '    set
    '    {
    '        // If the column string is blank, leave it blank.
    '        // The default width will be used for all columns.
    '        if (! Convert.ToBoolean(value.Trim().Length))
    '        {
    '            _ColumnNameString = "";
    '        }
    '        else if (value != null)
    '        {
    '            char[] delimiterChars = { ',', ';', ':' };
    '            string[] columnNames = value.Split(delimiterChars);

    '            if (!DesignMode)
    '            {
    '                _ColumnNames.Clear();
    '            }

    '            // After splitting the string into an array, iterate
    '            // through the strings and check that they're all valid.
    '            foreach (string s in columnNames)
    '            {
    '                // Does it have length?
    '                if (Convert.ToBoolean(s.Trim().Length))
    '                {
    '                    if (!DesignMode)
    '                    {
    '                        _ColumnNames.Add(s.Trim());
    '                    }
    '                }
    '                else // The value is blank
    '                {
    '                    throw new NotSupportedException("Column names can not be blank.");
    '                }
    '            }
    '            _ColumnNameString = value;
    '        }
    '    }
    '}
    Public Property ColumnNames As String
        Get
            Return _ColumnNameString
        End Get
        Set(value As String)
            ' If the column string is blank, leave it blank.
            ' The default width will be used for all columns.
            If Not Convert.ToBoolean(value.Trim().Length) Then
                _ColumnNameString = ""
            ElseIf (value IsNot Nothing) Then
                Dim delimiterChars As Char() = {","c, ";"c, ":"c}
                'Dim delimiterChars As Char() = {CChar(","), CChar(";"), CChar(":")}
                Dim columnNames As String() = value.Split(delimiterChars)

                If (Not DesignMode) Then
                    _ColumnNames.Clear()
                End If

                ' After splitting the string into an array, iterate
                ' through the strings and check that they're all valid.
                For Each s As String In columnNames
                    ' Does it have length?
                    If (Convert.ToBoolean(s.Trim().Length)) Then
                        If (Not DesignMode) Then
                            _ColumnNames.Add(s.Trim())
                        End If
                    Else ' The value is blank
                        Throw New NotSupportedException("Column names can not be blank.")
                    End If
                Next

                _ColumnNameString = value
            End If
        End Set
    End Property

    'public Collection<int> ColumnWidthCollection
    '{
    '    get
    '    {
    '        return _ColumnWidths;
    '    }
    '}
    Public ReadOnly Property ColumnWidthCollection As Collection(Of Integer)
        Get
            Return _ColumnWidths
        End Get
    End Property

    'public int ColumnWidthDefault
    '{
    '    get
    '    {
    '        return _ColumnWidthDefault;
    '    }
    '    set
    '    {
    '        _ColumnWidthDefault = value;
    '    }
    '}
    Public Property ColumnWidthDefault As Integer
        Get
            Return _ColumnWidthDefault
        End Get
        Set(value As Integer)
            _ColumnWidthDefault = value
        End Set
    End Property

    'public string ColumnWidths
    '{
    '    get
    '    {
    '        return _ColumnWidthString;
    '    }

    '    set
    '    {
    '        // If the column string is blank, leave it blank.
    '        // The default width will be used for all columns.
    '        if (! Convert.ToBoolean(value.Trim().Length))
    '        {
    '            _ColumnWidthString = "";
    '        }
    '        else if (value != null)
    '        {
    '            char[] delimiterChars = { ',', ';', ':' };
    '            string[] columnWidths = value.Split(delimiterChars);
    '            string invalidValue = "";
    '            int invalidIndex = -1;
    '            int idx = 1;
    '            int intValue;

    '            // After splitting the string into an array, iterate
    '            // through the strings and check that they're all integers
    '            // or blanks
    '            foreach (string s in columnWidths)
    '            {
    '                // If it has length, test if it's an integer
    '                if (Convert.ToBoolean(s.Trim().Length))
    '                {
    '                    // It's not an integer. Flag the offending value.
    '                    if (!int.TryParse(s, out intValue))
    '                    {
    '                        invalidIndex = idx;
    '                        invalidValue = s;
    '                    }
    '                    else // The value was okay. Increment the item index.
    '                    {
    '                        idx++;
    '                    }
    '                }
    '                else // The value is a space. Use the default width.
    '                {
    '                    idx++;
    '                }
    '            }

    '            // If an invalid value was found, raise an exception.
    '            if (invalidIndex > -1)
    '            {
    '                string errMsg;

    '                errMsg = "Invalid column width '" + invalidValue + "' located at column " + invalidIndex.ToString();
    '                throw new ArgumentOutOfRangeException(errMsg);
    '            }
    '            else // The string is fine
    '            {
    '                _ColumnWidthString = value;

    '                // Only set the values of the collections at runtime.
    '                // Setting them at design time doesn't accomplish 
    '                // anything and causes errors since the collections 
    '                // don't exist at design time.
    '                if (!DesignMode)
    '                {
    '                    _ColumnWidths.Clear();
    '                    foreach (string s in columnWidths)
    '                    {
    '                        // Initialize a column width to an integer
    '                        if (Convert.ToBoolean(s.Trim().Length))
    '                        {
    '                            _ColumnWidths.Add(Convert.ToInt32(s));
    '                        }
    '                        else // Initialize the column to the default
    '                        {
    '                            _ColumnWidths.Add(_ColumnWidthDefault);
    '                        }
    '                    }

    '                    // If the column is bound to data, set the column widths
    '                    // for any columns that aren't explicitly set by the 
    '                    // string value entered by the programmer
    '                    if (DataManager != null)
    '                    {
    '                        InitializeColumns();
    '                    }
    '                }
    '            }
    '        }
    '    }
    '}
    Public Property ColumnWidths As String
        Get
            Return _ColumnWidthString
        End Get
        Set(value As String)
            ' If the column string is blank, leave it blank.
            ' The default width will be used for all columns.
            If (Not Convert.ToBoolean(value.Trim().Length)) Then
                _ColumnWidthString = ""
            ElseIf (value IsNot Nothing) Then
                Dim delimiterChars As Char() = {","c, ";"c, ":"c}
                'Dim delimiterChars As Char() = {CChar(","), CChar(";"), CChar(":")}
                Dim columnWidths As String() = value.Split(delimiterChars)
                Dim invalidValue As String = String.Empty
                Dim invalidIndex As Integer = -1
                Dim idx As Integer = 1
                Dim intValue As Integer

                ' After splitting the string into an array, iterate
                ' through the strings and check that they're all integers
                ' or blanks
                For Each s As String In columnWidths
                    ' If it has length, test if it's an integer
                    If (Convert.ToBoolean(s.Trim().Length)) Then
                        ' It's not an integer. Flag the offending value.
                        If (Not Integer.TryParse(s, intValue)) Then
                            invalidIndex = idx
                            invalidValue = s
                        Else ' The value was okay. Increment the item index.
                            idx = idx + 1
                        End If
                    Else
                        idx = idx + 1
                    End If
                Next

                ' If an invalid value was found, raise an exception.
                If (invalidIndex > -1) Then
                    Dim errMsg As String

                    errMsg = "Invalid column width '" + invalidValue + "' located at column " + invalidIndex.ToString()
                    Throw New ArgumentOutOfRangeException(errMsg)
                Else ' The string is fine
                    _ColumnWidthString = value

                    ' Only set the values of the collections at runtime.
                    ' Setting them at design time doesn't accomplish 
                    ' anything and causes errors since the collections 
                    ' don't exist at design time.
                    If (Not DesignMode) Then
                        _ColumnWidths.Clear()
                        For Each s As String In columnWidths
                            ' Initialize a column width to an integer
                            If (Convert.ToBoolean(s.Trim().Length)) Then
                                _ColumnWidths.Add(Convert.ToInt32(s))
                            Else ' Initialize the column to the default
                                _ColumnWidths.Add(_ColumnWidthDefault)
                            End If
                        Next

                        ' If the column is bound to data, set the column widths
                        ' for any columns that aren't explicitly set by the 
                        ' string value entered by the programmer
                        If (DataManager IsNot Nothing) Then
                            InitializeColumns()
                        End If
                    End If
                End If ' End If (invalidIndex > -1)
            End If ' End If (Not Convert.ToBoolean(value.Trim().Length))
        End Set
    End Property

    'public new DrawMode DrawMode 
    '{ 
    '    get
    '    {
    '        return base.DrawMode;
    '    } 
    '    set
    '    {
    '        if (value != DrawMode.OwnerDrawVariable)
    '        {
    '            throw new NotSupportedException("Needs to be DrawMode.OwnerDrawVariable");
    '        }
    '        base.DrawMode = value;
    '    }
    '}
    Public Overloads Property DrawMode As DrawMode
        Get
            Return MyBase.DrawMode
        End Get
        Set(value As DrawMode)
            If (value <> DrawMode.OwnerDrawVariable) Then
                Throw New NotSupportedException("Needs to be DrawMode.OwnerDrawVariable")
            End If
            MyBase.DrawMode = value
        End Set
    End Property

    'public new ComboBoxStyle DropDownStyle
    '{ 
    '    get
    '    {
    '        return base.DropDownStyle;
    '    } 
    '    set
    '    {
    '        if (value != ComboBoxStyle.DropDown)
    '        {
    '            throw new NotSupportedException("ComboBoxStyle.DropDown is the only supported style");
    '        }
    '        base.DropDownStyle = value;
    '    } 
    '}
    Public Overloads Property DropDownStyle As ComboBoxStyle
        Get
            Return MyBase.DropDownStyle
        End Get
        Set(value As ComboBoxStyle)
            If (value <> ComboBoxStyle.DropDown) Then
                Throw New NotSupportedException("ComboBoxStyle.DropDown is the only supported style")
            End If
            MyBase.DropDownStyle = value
        End Set
    End Property

    'public int LinkedColumnIndex
    '{
    '    get 
    '    { 
    '        return _LinkedColumnIndex; 
    '    }
    '    set 
    '    {
    '        if (value < 0)
    '        {
    '            throw new ArgumentOutOfRangeException("A column index can not be negative");
    '        }
    '        _LinkedColumnIndex = value; 
    '    }
    '}
    Public Property LinkedColumnIndex1 As Integer
        Get
            Return _LinkedColumnIndex1
        End Get
        Set(value As Integer)
            If (value < 0) Then
                Throw New ArgumentOutOfRangeException("A column index can not be negative")
            End If
            _LinkedColumnIndex1 = value
        End Set
    End Property

    'public TextBox LinkedTextBox
    '{
    '    get 
    '    { 
    '        return _LinkedTextBox; 
    '    }
    '    set 
    '    { 
    '        _LinkedTextBox = value;

    '        if (_LinkedTextBox != null)
    '        {
    '            // Set any default properties of the Linked Textbox here
    '            _LinkedTextBox.ReadOnly = true;
    '            _LinkedTextBox.TabStop = false;
    '        }
    '    }
    '}
    Public Property LinkedTextBox1() As TextBox
        Get
            Return _LinkedTextBox1
        End Get
        Set(ByVal value As TextBox)
            _LinkedTextBox1 = value

            If (_LinkedTextBox1 IsNot Nothing) Then
                _LinkedTextBox1.ReadOnly = True
                _LinkedTextBox1.TabStop = False
            End If
        End Set
    End Property



    Public Property LinkedColumnIndex2 As Integer
        Get
            Return _LinkedColumnIndex2
        End Get
        Set(value As Integer)
            If (value < 0) Then
                Throw New ArgumentOutOfRangeException("A column index can not be negative")
            End If
            _LinkedColumnIndex2 = value
        End Set
    End Property

    Public Property LinkedTextBox2() As TextBox
        Get
            Return _LinkedTextBox2
        End Get
        Set(ByVal value As TextBox)
            _LinkedTextBox2 = value

            'If (_LinkedTextBox2 IsNot Nothing) Then
            '    _LinkedTextBox2.ReadOnly = True
            '    _LinkedTextBox2.TabStop = False
            'End If
        End Set
    End Property


    Public Property LinkedColumnIndex3 As Integer
        Get
            Return _LinkedColumnIndex3
        End Get
        Set(value As Integer)
            If (value < 0) Then
                Throw New ArgumentOutOfRangeException("A column index can not be negative")
            End If
            _LinkedColumnIndex3 = value
        End Set
    End Property

    Public Property LinkedTextBox3() As TextBox
        Get
            Return _LinkedTextBox3
        End Get
        Set(ByVal value As TextBox)
            _LinkedTextBox3 = value

            'If (_LinkedTextBox3 IsNot Nothing) Then
            '    _LinkedTextBox3.ReadOnly = True
            '    _LinkedTextBox3.TabStop = False
            'End If
        End Set
    End Property

    
    'public int TotalWidth
    '{
    '    get
    '    {
    '        return _TotalWidth;
    '    }
    '}
    Public ReadOnly Property TotalWidth() As Integer
        Get
            Return _TotalWidth
        End Get
    End Property


#End Region

#Region "Overrides Methods"
    'protected override void OnDataSourceChanged(EventArgs e)
    '{
    '    base.OnDataSourceChanged(e);

    '    InitializeColumns();
    '}
    Protected Overrides Sub OnDataSourceChanged(e As EventArgs)
        MyBase.OnDataSourceChanged(e)

        InitializeColumns()
    End Sub

    'protected override void OnDrawItem(DrawItemEventArgs e)
    '{
    '    base.OnDrawItem(e);

    '    if (DesignMode)
    '        return;

    '    e.DrawBackground();

    '    Rectangle boundsRect = e.Bounds;
    '    int lastRight = 0;

    '    Color brushForeColor;
    '    if ((e.State & DrawItemState.Selected) == 0)
    '    {   
    '        // Item is not selected. Use BackColorOdd & BackColorEven
    '        Color backColor;
    '        backColor = Convert.ToBoolean(e.Index % 2) ? _BackColorOdd : _BackColorEven;
    '        using (SolidBrush brushBackColor = new SolidBrush(backColor))
    '        {
    '            e.Graphics.FillRectangle(brushBackColor, e.Bounds);
    '        }
    '        brushForeColor = Color.Black;
    '    }
    '    else
    '    {
    '        // Item is selected. Use ForeColor = White
    '        brushForeColor = Color.White;
    '    }

    '    using (Pen linePen = new Pen(SystemColors.GrayText))
    '    {
    '        using (SolidBrush brush = new SolidBrush(brushForeColor))
    '        {
    '            if (! Convert.ToBoolean(_ColumnNames.Count))
    '            {
    '                e.Graphics.DrawString(Convert.ToString(Items[e.Index]), Font, brush, boundsRect);
    '            }
    '            else
    '            {
    '                // If the ComboBox is displaying a RightToLeft language, draw it this way.
    '                if (RightToLeft.Equals(RightToLeft.Yes))
    '                {
    '                    // Define a StringFormat object to make the string display RTL.
    '                    StringFormat rtl = new StringFormat();
    '                    rtl.Alignment = StringAlignment.Near;
    '                    rtl.FormatFlags = StringFormatFlags.DirectionRightToLeft;

    '                    // Draw the strings in reverse order from high column index to zero column index.
    '                    for (int colIndex = _ColumnNames.Count - 1; colIndex >= 0; colIndex--)
    '                    {
    '                        if (Convert.ToBoolean(_ColumnWidths[colIndex]))
    '                        {
    '                            string item = Convert.ToString(FilterItemOnProperty(Items[e.Index], _ColumnNames[colIndex]));

    '                            boundsRect.X = lastRight;
    '                            boundsRect.Width = (int)_ColumnWidths[colIndex];
    '                            lastRight = boundsRect.Right;

    '                            // Draw the string with the RTL object.
    '                            e.Graphics.DrawString(item, Font, brush, boundsRect, rtl);

    '                            if (colIndex > 0)
    '                            {
    '                                e.Graphics.DrawLine(linePen, boundsRect.Right, boundsRect.Top, boundsRect.Right, boundsRect.Bottom);
    '                            }
    '                        }
    '                    }
    '                }
    '                // If the ComboBox is displaying a LeftToRight language, draw it this way.
    '                else
    '                {
    '                    // Display the strings in ascending order from zero to the highest column.
    '                    for (int colIndex = 0; colIndex < _ColumnNames.Count; colIndex++)
    '                    {
    '                        if (Convert.ToBoolean(_ColumnWidths[colIndex]))
    '                        {
    '                            string item = Convert.ToString(FilterItemOnProperty(Items[e.Index], _ColumnNames[colIndex]));

    '                            boundsRect.X = lastRight;
    '                            boundsRect.Width = (int)_ColumnWidths[colIndex];
    '                            lastRight = boundsRect.Right;
    '                            e.Graphics.DrawString(item, Font, brush, boundsRect);

    '                            if (colIndex < _ColumnNames.Count - 1)
    '                            {
    '                                e.Graphics.DrawLine(linePen, boundsRect.Right, boundsRect.Top, boundsRect.Right, boundsRect.Bottom);
    '                            }
    '                        }
    '                    }
    '                }
    '            }
    '        }
    '    }

    '    e.DrawFocusRectangle();
    '}
    'protected override void OnDrawItem(DrawItemEventArgs e)
    Protected Overrides Sub OnDrawItem(e As DrawItemEventArgs)
        MyBase.OnDrawItem(e)

        If (DesignMode) Then Return

        e.DrawBackground()

        Dim boundsRect As Rectangle = e.Bounds
        Dim lastRight As Integer = 0

        Dim brushForeColor As Color
        'if ((e.State & DrawItemState.Selected) == 0)
        If (e.State And DrawItemState.Selected) = 0 Then
            ' Item is not selected. Use BackColorOdd & BackColorEven
            Dim backColor As Color
            backColor = If(Convert.ToBoolean(e.Index Mod 2), _BackColorOdd, _BackColorEven)

            'using (SolidBrush brushBackColor = new SolidBrush(backColor))
            '{
            '    e.Graphics.FillRectangle(brushBackColor, e.Bounds);
            '}
            Using brushBackColor As SolidBrush = New SolidBrush(backColor)
                e.Graphics.FillRectangle(brushBackColor, e.Bounds)
            End Using

            brushForeColor = Color.Black
        Else
            ' Item is selected. Use ForeColor = White
            brushForeColor = Color.White
        End If

        Using linePen As Pen = New Pen(SystemColors.GrayText)
            Using brush As SolidBrush = New SolidBrush(brushForeColor)
                If (Not Convert.ToBoolean(_ColumnNames.Count)) Then
                    e.Graphics.DrawString(Convert.ToString(Items(e.Index)), Font, brush, boundsRect)
                Else
                    ' If the ComboBox is displaying a RightToLeft language, draw it this way.
                    If (RightToLeft.Equals(RightToLeft.Yes)) Then
                        ' Define a StringFormat object to make the string display RTL.
                        Dim rtl As StringFormat = New StringFormat()
                        rtl.Alignment = StringAlignment.Near
                        rtl.FormatFlags = StringFormatFlags.DirectionRightToLeft

                        ' Draw the strings in reverse order from high column index to zero column index.
                        'for (int colIndex = _ColumnNames.Count - 1; colIndex >= 0; colIndex--)
                        For colIndex As Integer = _ColumnNames.Count - 1 To CInt(colIndex >= 0) Step -1
                            If (Convert.ToBoolean(_ColumnWidths(colIndex))) Then
                                Dim item As String = Convert.ToString(FilterItemOnProperty(Items(e.Index), _ColumnNames(colIndex)))

                                boundsRect.X = lastRight
                                boundsRect.Width = CInt(_ColumnWidths(colIndex))
                                lastRight = boundsRect.Right

                                ' Draw the string with the RTL object.
                                e.Graphics.DrawString(item, Font, brush, boundsRect, rtl)

                                If (colIndex > 0) Then
                                    e.Graphics.DrawLine(linePen, boundsRect.Right, boundsRect.Top, boundsRect.Right, boundsRect.Bottom)
                                End If

                            End If ' End If (Convert.ToBoolean(_ColumnWidths(colIndex)))
                        Next

                    Else ' If the ComboBox is displaying a LeftToRight language, draw it this way.
                        ' Display the strings in ascending order from zero to the highest column.
                        'for (int colIndex = 0; colIndex < _ColumnNames.Count; colIndex++)
                        For colIndex As Integer = 0 To _ColumnNames.Count - 1 Step 1
                            If (Convert.ToBoolean(_ColumnWidths(colIndex))) Then
                                Dim item As String = Convert.ToString(FilterItemOnProperty(Items(e.Index), _ColumnNames(colIndex)))

                                boundsRect.X = lastRight
                                boundsRect.Width = CInt(_ColumnWidths(colIndex))
                                lastRight = boundsRect.Right
                                e.Graphics.DrawString(item, Font, brush, boundsRect)

                                If (colIndex < _ColumnNames.Count - 1) Then
                                    e.Graphics.DrawLine(linePen, boundsRect.Right, boundsRect.Top, boundsRect.Right, boundsRect.Bottom)
                                End If

                            End If ' End If (Convert.ToBoolean(_ColumnWidths(colIndex)))
                        Next
                    End If ' End If (RightToLeft.Equals(RightToLeft.Yes))

                End If ' End If (Not Convert.ToBoolean(_ColumnNames.Count))
            End Using
        End Using

        e.DrawFocusRectangle()
    End Sub

    'protected override void OnDropDown(EventArgs e)
    '{
    '    base.OnDropDown(e);

    '    if (_TotalWidth > 0)
    '    {
    '        if (Items.Count > MaxDropDownItems)
    '        {
    '            // The vertical scrollbar is present. Add its width to the total.
    '            // If you don't then RightToLeft languages will have a few characters obscured.
    '            this.DropDownWidth = _TotalWidth + SystemInformation.VerticalScrollBarWidth;
    '        }
    '        else
    '        {
    '            this.DropDownWidth = _TotalWidth;
    '        }
    '    }
    '}
    Protected Overrides Sub OnDropDown(e As EventArgs)
        MyBase.OnDropDown(e)

        If (_TotalWidth > 0) Then
            If (Items.Count > MaxDropDownItems) Then
                ' The vertical scrollbar is present. Add its width to the total.
                ' If you don't then RightToLeft languages will have a few characters obscured.
                Me.DropDownWidth = _TotalWidth + SystemInformation.VerticalScrollBarWidth
            Else
                Me.DropDownWidth = _TotalWidth
            End If
        End If
    End Sub

    'protected override void OnKeyDown(KeyEventArgs e)
    '{
    '    // Use the Delete or Escape Key to blank out the ComboBox and
    '    // allow the user to type in a new value
    '    if ((e.KeyCode == Keys.Delete) ||
    '        (e.KeyCode == Keys.Escape))
    '    {
    '        SelectedIndex = -1;
    '        Text = "";
    '        if (_LinkedTextBox != null)
    '        {
    '            _LinkedTextBox.Text = "";
    '        }
    '    }
    '    else if (e.KeyCode == Keys.F3)
    '    {
    '        // Fire the OpenSearchForm Event
    '        if (OpenSearchForm != null)
    '        {
    '            OpenSearchForm(this, System.EventArgs.Empty);
    '        }
    '    }
    '}
    Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
        'MyBase.OnKeyDown(e)

        ' Use the Delete or Escape Key to blank out the ComboBox and
        ' allow the user to type in a new value
        If ((e.KeyCode = Keys.Delete) OrElse (e.KeyCode = Keys.Escape)) Then
            SelectedIndex = -1
            Text = ""

            If (_LinkedTextBox1 IsNot Nothing) Then
                _LinkedTextBox1.Text = ""
            End If

            If (_LinkedTextBox2 IsNot Nothing) Then
                _LinkedTextBox2.Text = ""
            End If

            If (_LinkedTextBox3 IsNot Nothing) Then
                _LinkedTextBox3.Text = ""
            End If

        ElseIf (e.KeyCode = Keys.F3) Then
            ' Fire the OpenSearchForm Event
            'If (OpenSearchForm IsNot Nothing) Then
            '    ' 'Public Event OpenSearchForm(sender as Object, e As System.EventArgs)' is and event, and cannot be called directly. Use a 'RaiseEvent' statement to raise an event.
            '    RaiseEvent OpenSearchForm(Me, System.EventArgs.Empty)
            'End If
            Try
                RaiseEvent OpenSearchForm(Me, System.EventArgs.Empty)
            Catch ex As Exception
                'TODO:
            End Try
        End If ' End If ((e.KeyCode = Keys.Delete) OrElse (e.KeyCode = Keys.Escape))
    End Sub

    '// Some of the code for OnKeyPress was derived from some VB.NET code  
    '// posted by Laurent Muller as a suggested improvement for another control.
    '// http://www.codeproject.com/vb/net/autocomplete_combobox.asp?df=100&forumid=3716&select=579095#xx579095xx
    'protected override void OnKeyPress(KeyPressEventArgs e)
    '{
    '    int idx = -1;
    '    string toFind;

    '    DroppedDown = _AutoDropdown;
    '    if (!Char.IsControl(e.KeyChar))
    '    {
    '        if (_AutoComplete)
    '        {
    '            toFind = Text.Substring(0, SelectionStart) + e.KeyChar;
    '            idx = FindStringExact(toFind);

    '            if (idx == -1)
    '            {
    '                // An exact match for the whole string was not found
    '                // Find a substring instead.
    '                idx = FindString(toFind);
    '            }
    '            else
    '            {
    '                // An exact match was found. Close the dropdown.
    '                DroppedDown = false;
    '            }

    '            if (idx != -1) // The substring was found.
    '            {
    '                SelectedIndex = idx;
    '                SelectionStart = toFind.Length;
    '                SelectionLength = Text.Length - SelectionStart;
    '            }
    '            else // The last keystroke did not create a valid substring.
    '            {
    '                // If the substring is not found, cancel the keypress
    '                e.KeyChar = (char)0;
    '            }
    '        }
    '        else // AutoComplete = false. Treat it like a DropDownList by finding the
    '             // KeyChar that was struck starting from the current index
    '        {
    '            idx = FindString(e.KeyChar.ToString(), SelectedIndex);

    '            if (idx != -1)
    '            {
    '                SelectedIndex = idx;
    '            }
    '        }
    '    }

    '    // Do no allow the user to backspace over characters. Treat it like
    '    // a left arrow instead. The user must not be allowed to change the 
    '    // value in the ComboBox. 
    '    if ((e.KeyChar == (char)(Keys.Back)) &&  // A Backspace Key is hit
    '        (_AutoComplete) &&                   // AutoComplete = true
    '        (Convert.ToBoolean(SelectionStart))) // And the SelectionStart is positive
    '    {
    '        // Find a substring that is one character less the the current selection.
    '        // This mimicks moving back one space with an arrow key. This substring should
    '        // always exist since we don't allow invalid selections to be typed. If you're
    '        // on the 3rd character of a valid code, then the first two characters have to 
    '        // be valid. Moving back to them and finding the 1st occurrence should never fail.
    '        toFind = Text.Substring(0, SelectionStart - 1);
    '        idx = FindString(toFind);

    '        if (idx != -1)
    '        {
    '            SelectedIndex = idx;
    '            SelectionStart = toFind.Length;
    '            SelectionLength = Text.Length - SelectionStart;
    '        }
    '    }

    '    // e.Handled is always true. We handle every keystroke programatically.
    '    e.Handled = true;
    '}
    ' Some of the code for OnKeyPress was derived from some VB.NET code  
    ' posted by Laurent Muller as a suggested improvement for another control.
    ' http://www.codeproject.com/vb/net/autocomplete_combobox.asp?df=100&forumid=3716&select=579095#xx579095xx
    'protected override void OnKeyPress(KeyPressEventArgs e)
    Protected Overrides Sub OnKeyPress(e As KeyPressEventArgs)
        'MyBase.OnKeyPress(e)
        Dim idx As Integer = -1
        Dim toFind As String = String.Empty

        DroppedDown = _AutoDropdown

        If (Not Char.IsControl(e.KeyChar)) Then

            If (_AutoComplete) Then

                toFind = Text.Substring(0, SelectionStart) + e.KeyChar
                idx = FindStringExact(toFind)

                If (idx = -1) Then
                    ' An exact match for the whole string was not found
                    ' Find a substring instead.
                    idx = FindString(toFind)
                Else
                    ' An exact match was found. Close the dropdown.
                    DroppedDown = False
                End If

                If (idx <> -1) Then ' The substring was found.
                    SelectedIndex = idx
                    SelectionStart = toFind.Length
                    SelectionLength = Text.Length - SelectionStart
                Else ' The last keystroke did not create a valid substring.
                    ' If the substring is not found, cancel the keypress
                    e.KeyChar = CChar("0")
                End If 'End If (idx <> -1)

            Else ' AutoComplete = false. Treat it like a DropDownList by finding the
                '  KeyChar that was struck starting from the current index

                idx = FindString(e.KeyChar.ToString(), SelectedIndex)

                If (idx <> -1) Then
                    SelectedIndex = idx
                End If

            End If  'End If (_AutoComplete)

        End If 'End If (Not Char.IsControl(e.KeyChar))


        ' Do no allow the user to backspace over characters. Treat it like
        ' a left arrow instead. The user must not be allowed to change the 
        ' value in the ComboBox.
        If ((e.KeyChar.Equals(Keys.Back)) AndAlso _
            (_AutoComplete) AndAlso _
            (Convert.ToBoolean(SelectionStart))) Then
            'A Backspace Key is hit
            'AutoComplete = true
            'And the SelectionStart is positive

            ' Find a substring that is one character less the the current selection.
            ' This mimicks moving back one space with an arrow key. This substring should
            ' always exist since we don't allow invalid selections to be typed. If you're
            ' on the 3rd character of a valid code, then the first two characters have to 
            ' be valid. Moving back to them and finding the 1st occurrence should never fail.
            toFind = Text.Substring(0, SelectionStart - 1)
            idx = FindString(toFind)

            If (idx <> -1) Then
                SelectedIndex = idx
                SelectionStart = toFind.Length
                SelectionLength = Text.Length - SelectionStart
            End If

        End If

        ' e.Handled is always true. We handle every keystroke programatically.
        e.Handled = True

    End Sub

    'protected override void OnSelectedValueChanged(EventArgs e)
    '{
    '    base.OnSelectedValueChanged(e); //Added after version 1.3 on 01/31/2008

    '    if (_LinkedTextBox != null)
    '    {
    '        if (_LinkedColumnIndex < _ColumnNames.Count)
    '        {
    '            _LinkedTextBox.Text = Convert.ToString(FilterItemOnProperty(SelectedItem, _ColumnNames[_LinkedColumnIndex]));
    '        }
    '    }
    '}
    Protected Overrides Sub OnSelectedValueChanged(e As EventArgs)
        MyBase.OnSelectedValueChanged(e)    '//Added after version 1.3 on 01/31/2008

        If (_LinkedTextBox1 IsNot Nothing) Then
            If (_LinkedColumnIndex1 < _ColumnNames.Count) Then
                _LinkedTextBox1.Text = Convert.ToString(FilterItemOnProperty(SelectedItem, _ColumnNames(_LinkedColumnIndex1)))
            End If
        End If

        If (_LinkedTextBox2 IsNot Nothing) Then
            If (_LinkedColumnIndex2 < _ColumnNames.Count) Then
                _LinkedTextBox2.Text = Convert.ToString(FilterItemOnProperty(SelectedItem, _ColumnNames(_LinkedColumnIndex2)))
            End If
        End If

        If (_LinkedTextBox3 IsNot Nothing) Then
            If (_LinkedColumnIndex3 < _ColumnNames.Count) Then
                _LinkedTextBox3.Text = Convert.ToString(FilterItemOnProperty(SelectedItem, _ColumnNames(_LinkedColumnIndex3)))
            End If
        End If
    End Sub

    'protected override void OnValueMemberChanged(EventArgs e)
    '{
    '    base.OnValueMemberChanged(e);

    '    InitializeValueMemberColumn();
    '}
    Protected Overrides Sub OnValueMemberChanged(e As EventArgs)
        MyBase.OnValueMemberChanged(e)

        InitializeValueMemberColumn()
    End Sub
#End Region

#Region "Sub, Functions"
    'private void InitializeColumns()
    '{
    '    if (!Convert.ToBoolean(_ColumnNameString.Length))
    '    {
    '        PropertyDescriptorCollection propertyDescriptorCollection = DataManager.GetItemProperties();

    '        _TotalWidth = 0;
    '        _ColumnNames.Clear();

    '        for (int colIndex = 0; colIndex < propertyDescriptorCollection.Count; colIndex++)
    '        {
    '            _ColumnNames.Add(propertyDescriptorCollection[colIndex].Name);

    '            // If the index is greater than the collection of explicitly
    '            // set column widths, set any additional columns to the default
    '            if (colIndex >= _ColumnWidths.Count)
    '            {
    '                _ColumnWidths.Add(_ColumnWidthDefault);
    '            }
    '            _TotalWidth += _ColumnWidths[colIndex];
    '        }
    '    }
    '    else
    '    {
    '        _TotalWidth = 0;

    '        for (int colIndex = 0; colIndex < _ColumnNames.Count; colIndex++)
    '        {
    '            // If the index is greater than the collection of explicitly
    '            // set column widths, set any additional columns to the default
    '            if (colIndex >= _ColumnWidths.Count)
    '            {
    '                _ColumnWidths.Add(_ColumnWidthDefault);
    '            }
    '            _TotalWidth += _ColumnWidths[colIndex];
    '        }

    '    }

    '    // Check to see if the programmer is trying to display a column
    '    // in the linked textbox that is greater than the columns in the 
    '    // ComboBox. I handle this error by resetting it to zero.
    '    if (_LinkedColumnIndex >= _ColumnNames.Count)
    '    {
    '        _LinkedColumnIndex = 0; // Or replace this with an OutOfBounds Exception
    '    }
    '}
    Private Sub InitializeColumns()
        If (Not Convert.ToBoolean(_ColumnNameString.Length)) Then
            Dim propertyDescriptorCollection As PropertyDescriptorCollection = DataManager.GetItemProperties()

            _TotalWidth = 0
            _ColumnNames.Clear()

            'for (int colIndex = 0; colIndex < propertyDescriptorCollection.Count; colIndex++)
            For colIndex As Integer = 0 To propertyDescriptorCollection.Count - 1
                _ColumnNames.Add(propertyDescriptorCollection(colIndex).Name)

                '// If the index is greater than the collection of explicitly
                '// set column widths, set any additional columns to the default
                If (colIndex >= _ColumnWidths.Count) Then
                    _ColumnWidths.Add(_ColumnWidthDefault)
                End If
                _TotalWidth = _TotalWidth + _ColumnWidths(colIndex)
            Next
        Else
            _TotalWidth = 0

            'for (int colIndex = 0; colIndex < _ColumnNames.Count; colIndex++)
            For colIndex As Integer = 0 To _ColumnNames.Count - 1
                ' If the index is greater than the collection of explicitly
                ' set column widths, set any additional columns to the default
                If (colIndex >= _ColumnWidths.Count) Then
                    _ColumnWidths.Add(_ColumnWidthDefault)
                End If
                _TotalWidth += _ColumnWidths(colIndex)
            Next
        End If 'End If (Not Convert.ToBoolean(_ColumnNameString.Length))

        ' Check to see if the programmer is trying to display a column
        ' in the linked textbox that is greater than the columns in the 
        ' ComboBox. I handle this error by resetting it to zero.
        If (_LinkedColumnIndex1 >= _ColumnNames.Count) Then
            _LinkedColumnIndex1 = 0  ' Or replace this with an OutOfBounds Exception
        End If

    End Sub

    'private void InitializeValueMemberColumn()
    '{
    '    int colIndex = 0;
    '    foreach (String columnName in _ColumnNames)
    '    {
    '        if (String.Compare(columnName, ValueMember, true, CultureInfo.CurrentUICulture) == 0)
    '        {
    '            _ValueMemberColumnIndex = colIndex;
    '            break;
    '        }
    '        colIndex++;
    '    }
    '}
    Private Sub InitializeValueMemberColumn()
        Dim colIndex As Integer = 0
        For Each columnName As String In _ColumnNames
            If (String.Compare(columnName, ValueMember, True, CultureInfo.CurrentUICulture) = 0) Then

                _ValueMemberColumnIndex = colIndex
                Exit For
            End If
            colIndex = colIndex + 1
        Next
    End Sub
#End Region

End Class

'End Namespace


