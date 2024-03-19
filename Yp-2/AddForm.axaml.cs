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

public partial class AddEditForm : Window
{
    private List<Service> _Services;
    private Service CurrentServ;

    public AddEditForm(Service currentServ, List<Service> _services)
    {
        InitializeComponent();
        CurrentServ = currentServ;
        this.DataContext = currentServ;
        _Services = _services;
       
    }

    private MySqlConnection conn;
    string connStr = "server=localhost; database=yp-02; port=3306; User Id=root;password=Pass&_word1";

    private void Save_OnClick(object? sender, RoutedEventArgs e)
    {
        var usr = _Services.FirstOrDefault(x => x.ID == CurrentServ.ID);
        if (usr == null)
        {
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                string add =
                    "INSERT INTO services (name, discount,  duration, price, image_id) VALUES ('" +
                    Name.Text + "', '" + Convert.ToDouble(discount.Text) + "', '" + duration.Text + "', '" + price.Text + "', '" +
                    Img.Text + "');";
                MySqlCommand cmd = new MySqlCommand(add, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                Servic back = new Servic();
                this.Close();
                back.Show();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error" + exception);
            }
        }
        else
        {
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                string upd = "UPDATE services SET name = '" + Name.Text +
                             "', discount = '" + Convert.ToInt32(discount.Text) + "', duration = '" +
                             duration.Text + 
                             "', price = '" + price.Text +  "', image_id = '" +
                             Img.Text + "' WHERE ID = " + Convert.ToInt32(ID.Text) + ";";
                MySqlCommand cmd = new MySqlCommand(upd, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                
                Servic back = new Servic();
                this.Close();
                back.Show();
            }
            catch (Exception exception)
            {
                Console.Write("Error" + exception);
            }
        }
    }

    private void GoBack(object? sender, RoutedEventArgs e)
    {
        Servic back = new Servic();
        this.Close();
        back.Show();
    }

    private async void File_Select(object sender, RoutedEventArgs e)
    {
        try
        {
            OpenFileDialog fileDialog = new OpenFileDialog(); //создание диалогового окна выбора файла
            fileDialog.Filters.Add(new FileDialogFilter() { Name = "Image Files", Extensions = { "jpg", "jpeg", "png", "gif" } }); //ограничение на выбор только изображений
            string[]? fileNames = await fileDialog.ShowAsync(this); //отображение диалогового окна и получение выбранных файлов
            if (fileNames != null && fileNames.Length > 0) //если файл выбран
            {
                string imagePath = System.IO.Path.GetFileName(fileNames[0]); //получение пути к выбранному файлу
                Img.Text = imagePath;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
}