Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dataTable2 As DataTable = New DataTable("Food")

        dataTable2.Columns.Add("ProductCode", GetType(System.String))
        dataTable2.Columns.Add("Category", GetType(System.String))
        dataTable2.Columns.Add("Desciption", GetType(System.String))

        dataTable2.Rows.Add(New String() {"123", "Fruit", "Apple"})
        dataTable2.Rows.Add(New String() {"127", "Fruit", "Grapes"})
        dataTable2.Rows.Add(New String() {"135", "Fruit", "Bananas"})
        dataTable2.Rows.Add(New String() {"138", "Fruit", "Oranges"})
        dataTable2.Rows.Add(New String() {"142", "Fruit", "Pears"})
        dataTable2.Rows.Add(New String() {"201", "Vegetable", "Carrots"})
        dataTable2.Rows.Add(New String() {"207", "Vegetable", "Lettuce"})
        dataTable2.Rows.Add(New String() {"209", "Vegetable", "Peas"})
        dataTable2.Rows.Add(New String() {"213", "Vegetable", "Corn"})
        dataTable2.Rows.Add(New String() {"218", "Vegetable", "Spinach"})
        dataTable2.Rows.Add(New String() {"341", "Dairy", "Milk"})
        dataTable2.Rows.Add(New String() {"343", "Dairy", "Cheese"})
        dataTable2.Rows.Add(New String() {"345", "Dairy", "Yogurt"})
        dataTable2.Rows.Add(New String() {"382", "Dairy", "Ice Cream"})
        dataTable2.Rows.Add(New String() {"387", "Dairy", "Butter"})

        MultiColumnComboBox1.DataSource = dataTable2
        MultiColumnComboBox1.DisplayMember = "ProductCode"
        MultiColumnComboBox1.ValueMember = "ProductCode"
        MultiColumnComboBox1.SelectedIndex = -1
        MultiColumnComboBox1.Text = ""
    End Sub

    Private Sub multiColumnComboBox2_OpenSearchForm(sender As Object, e As EventArgs) Handles MultiColumnComboBox1.OpenSearchForm
        Dim newForm As FormSearch = New FormSearch(DirectCast(sender, MultiColumnComboBox))
        newForm.ShowDialog()
    End Sub
End Class