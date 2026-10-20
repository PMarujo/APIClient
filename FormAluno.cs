using APIClient.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APIClient
{
    public partial class FormAluno : Form
    {
        public FormAluno()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormAluno_Load(object sender, EventArgs e)
        {

        }


        private async Task CarregarListaAlunos()
        {
            try
            {
                var alunos = await APIService.ObterAlunosAsync();
                dgvAlunos.DataSource = null;
                dgvAlunos.DataSource = alunos;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Erro ao carregar lista", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
