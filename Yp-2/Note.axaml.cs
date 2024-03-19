using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySql.Data.MySqlClient;
using System;
using System.Windows;


namespace Yp_2;

public partial class Note : Window
{
    private List<Record> _rec;

    public Note()
    {
        InitializeComponent();
    }

    private MySqlConnection conn;
    string connStr = "server=localhost; database=yp-02; port=3306; User Id=root;password=Pass&_word1";

    private void Save_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            string add = "INSERT INTO note (ID, client_id, employee_id, service_id, date) VALUES ('" + ID.Text + "', '" + client_id.Text + "', '" + employee_id.Text + "', '" + service_id.Text + "', '" + date.Text + "');";
            MySqlCommand cmd = new MySqlCommand(add, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void GoBack(object? sender, RoutedEventArgs e)
    {
        Servic back = new Servic();
        this.Close();
        back.Show();
    }
}