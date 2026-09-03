using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoWinFormsApi
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly DatabaseService dbService = new DatabaseService();

        public Form1()
        {
            InitializeComponent();
        }

        // Tasto 1: Scarica da API e Salva su SQL
        private async void OnClickLoadData(object sender, EventArgs e)
        {
            btnLoadData.Enabled = false;
            lblState.Text = "Downloading from API and saving to SQL...";

            try
            {
                List<PostDto> apiData = await GetDataFromApi();
                await dbService.SaveDataToSqlAsync(apiData);

                lblState.Text = $"Successfully downloaded and saved {apiData.Count} records to SQL!";
            }
            catch (Exception ex)
            {
                lblState.Text = "Error during API download or SQL save.";
                MessageBox.Show($"Details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLoadData.Enabled = true;
            }
        }

        private async Task<List<PostDto>> GetDataFromApi()
        {
            string url = "https://jsonplaceholder.typicode.com/posts";
            string jsonResponse = await client.GetStringAsync(url);

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<List<PostDto>>(jsonResponse, options);
        }

        private async void btnLoadFromDatabase(object sender, EventArgs e)
        {
            btnLoadFromDb.Enabled = false;
            lblState.Text = "Reading directly from SQLite DB...";

            try
            {
                List<PostDto> dbData = await dbService.ReadDataFromSqlAsync();
                dgvData.DataSource = dbData;

                lblState.Text = $"Loaded {dbData.Count} records directly from SQL DB!";
            }
            catch (Exception ex)
            {
                lblState.Text = "Error reading from SQL DB.";
                MessageBox.Show($"Details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLoadFromDb.Enabled = true;
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}