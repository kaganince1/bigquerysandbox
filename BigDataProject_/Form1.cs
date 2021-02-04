using Google.Apis.Bigquery.v2;
using Google.Apis.Bigquery.v2.Data;
using Google.Cloud.BigQuery.V2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigDataProject_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void WriteRows(IList<TableRow> rows, IList<TableFieldSchema> fields)
        {
            throw new NotImplementedException();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (txtboxQuery.Text.Length == 0)
            {
                System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "D:/İndirilenler/key.json");
                var client = BigQueryClient.Create("molten-method-300611");
                var table = client.GetTable("molten-method-300611", "deneme", "movies");
                var sql = $"SELECT * FROM `molten-method-300611.deneme.movies` order by movieId asc limit 100";
                var results = client.ExecuteQuery(sql, parameters: null);
                List<string> deneme = new List<string>();
                foreach (var row in results)
                {
                    deneme.Add(($"ID: {row["movieId"]} Title: {row["title"]} Genres: {row["genres"]}"));
                }
                var result = deneme.Select(s => new { value = s }).ToList();
                dataGridView1.DataSource = result;
            }
            else
            {
                System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "D:/İndirilenler/key.json");
                var client = BigQueryClient.Create("molten-method-300611");
                var table = client.GetTable("molten-method-300611", "deneme", "movies");
                string query = "SELECT * FROM `molten-method-300611.deneme.movies` where movieId = "+int.Parse(txtboxQuery.Text)+" order by movieId asc limit 100";
                var sql = query;
                var results = client.ExecuteQuery(sql, parameters: null);
                List<string> deneme = new List<string>();
                foreach (var row in results)
                {
                    deneme.Add(($"ID: {row["movieId"]} Title: {row["title"]} Genres: {row["genres"]}"));
                }
                var result = deneme.Select(s => new { value = s }).ToList();
                dataGridView1.DataSource = result;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "D:/İndirilenler/key.json");
            var client = BigQueryClient.Create("molten-method-300611");
            var table = client.GetTable("molten-method-300611", "deneme", "movies");
            string query = "SELECT * FROM `molten-method-300611.deneme.movies` where title like '%" + textBox1.Text + "%' limit 100";
            var sql = query;
            var results = client.ExecuteQuery(sql, parameters: null);
            List<string> deneme = new List<string>();
            foreach (var row in results)
            {
                deneme.Add(($"ID: {row["movieId"]} Title: {row["title"]} Genres: {row["genres"]}"));
            }
            var result = deneme.Select(s => new { value = s }).ToList();
            dataGridView1.DataSource = result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "D:/İndirilenler/key.json");
            var client = BigQueryClient.Create("molten-method-300611");
            var table = client.GetTable("molten-method-300611", "deneme", "movies");
            string query = "SELECT * FROM `molten-method-300611.deneme.movies` where genres like '%" + textBox2.Text + "%' limit 100";
            var sql = query;
            var results = client.ExecuteQuery(sql, parameters: null);
            List<string> deneme = new List<string>();
            foreach (var row in results)
            {
                deneme.Add(($"ID: {row["movieId"]} Title: {row["title"]} Genres: {row["genres"]}"));
            }
            var result = deneme.Select(s => new { value = s }).ToList();
            dataGridView1.DataSource = result;
        }
    }
}
