using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Windows;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using Avalonia.Utilities;
using System;
using System.Globalization;
using System.Runtime.InteropServices.JavaScript;
namespace Yp_2;

public class Service
{
    public int ID { get; set; }
    public string name { get; set; }
    public int discount { get; set; }
    public string duration { get; set; }
    public int price { get; set; }
    public int price_discount { get; set; }
    public Bitmap? image_id { get; set; }
    public string Изображение_услуги_путь { get; set; }
}

public class Record
{
    public int ID { get; set; }
    public int client_id { get; set; }
    public int employee_id { get; set; }
    public int service_id { get; set; }
    public int date { get; set; }
}
