using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_3_PI_DS
{
    /// <summary>
    /// Formulário principal do sistema ERP 4 Corações.
    /// Contém navegação lateral e telas: Dashboard, Estoque, Clientes,
    /// Produção e Relatórios.
    /// </summary>
    public partial class Form1 : Form
    {
        // ---------------------------
        // BANCO DE DADOS EM MEMÓRIA
        // ---------------------------
        private List<Produto> Produtos = new List<Produto>();
        private List<Cliente> Clientes = new List<Cliente>();
        private List<Producao> Producoes = new List<Producao>();

        // ---------------------------
        // COMPONENTES DA INTERFACE
        // ---------------------------
        private Panel painelMenu;
        private Panel painelConteudo;
        private DataGridView grid;

        // Inputs (criados dinamicamente)
        private TextBox txtNomeProduto, txtCategoria, txtPreco;
        private TextBox txtNomeCliente, txtTelefone;
        private NumericUpDown nudQuantidade, nudQtdProducao;
        private DateTimePicker dtpData;

        // ---------------------------
        // CONSTRUTOR
        // ---------------------------
        public Form1()
        {
            InitializeComponent();
        }

        // ---------------------------
        // INICIALIZAÇÃO DO FORM
        // ---------------------------
        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.ClientSize = new Size(1000, 600);
            this.Name = "Form1";
            this.Text = "ERP 4 Corações";
            this.Load += new EventHandler(Form1_Load);

            this.ResumeLayout(false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CriarInterface();
        }

        // ---------------------------
        // MODELOS SIMPLES
        // ---------------------------
        private class Produto
        {
            public string Nome { get; set; }
            public string Categoria { get; set; }
            public int Quantidade { get; set; }
            public double Preco { get; set; }
        }

        private class Cliente
        {
            public string Nome { get; set; }
            public string Telefone { get; set; }
        }

        private class Producao
        {
            public DateTime Data { get; set; }
            public int Quantidade { get; set; }
        }

        // ---------------------------
        // CRIAÇÃO DA INTERFACE
        // ---------------------------
        private void CriarInterface()
        {
            // Cor de fundo principal
            this.BackColor = Color.FromArgb(140, 90, 60);

            // ---------------------------
            // MENU LATERAL
            // ---------------------------
            painelMenu = new Panel();
            painelMenu.Size = new Size(200, this.Height);
            painelMenu.BackColor = Color.FromArgb(110, 70, 45);
            this.Controls.Add(painelMenu);

            CriarBotaoMenu("Dashboard", 0, BtnDashboard_Click);
            CriarBotaoMenu("Estoque", 50, BtnEstoque_Click);
            CriarBotaoMenu("Clientes", 100, BtnClientes_Click);
            CriarBotaoMenu("Produção", 150, BtnProducao_Click);
            CriarBotaoMenu("Relatórios", 200, BtnRelatorios_Click);

            // ---------------------------
            // PAINEL PRINCIPAL
            // ---------------------------
            painelConteudo = new Panel();
            painelConteudo.Location = new Point(200, 0);
            painelConteudo.Size = new Size(this.Width - 200, this.Height);
            painelConteudo.BackColor = Color.FromArgb(166, 117, 77);
            this.Controls.Add(painelConteudo);

            MostrarDashboard();
        }

        private void CriarBotaoMenu(string texto, int top, EventHandler acao)
        {
            Button btn = new Button();
            btn.Text = texto;
            btn.SetBounds(10, top, 180, 40);
            btn.BackColor = Color.FromArgb(70, 40, 20);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;

            btn.Click += acao;
            painelMenu.Controls.Add(btn);
        }

        // ---------------------------
        // TELAS DO SISTEMA
        // ---------------------------

        private void MostrarDashboard()
        {
            painelConteudo.Controls.Clear();

            Label lbl = new Label();
            lbl.Text =
                "SISTEMA ERP - BENEFÍCIOS\n\n" +
                "• Gestão integrada\n" +
                "• Controle de estoque\n" +
                "• Planejamento de produção\n" +
                "• Relatórios e análises\n" +
                "• Logística e entrega\n" +
                "• Atendimento ao cliente";

            lbl.Font = new Font("Arial", 18, FontStyle.Bold);
            lbl.ForeColor = Color.White;
            lbl.AutoSize = true;
            lbl.Location = new Point(20, 20);

            painelConteudo.Controls.Add(lbl);
        }

        private void MostrarEstoque()
        {
            painelConteudo.Controls.Clear();

            AddLabel("Nome:", 20, 20);
            txtNomeProduto = AddTextbox(120, 20);

            AddLabel("Categoria:", 20, 60);
            txtCategoria = AddTextbox(120, 60);

            AddLabel("Qtd:", 20, 100);
            nudQuantidade = new NumericUpDown();
            nudQuantidade.SetBounds(120, 100, 80, 25);
            painelConteudo.Controls.Add(nudQuantidade);

            AddLabel("Preço:", 20, 140);
            txtPreco = AddTextbox(120, 140);

            Button btnAdd = AddButton("Adicionar Produto", 20, 180);
            btnAdd.Click += BtnAddProduto_Click;

            grid = AddGrid(20, 230);
            grid.DataSource = Produtos;
        }

        private void MostrarClientes()
        {
            painelConteudo.Controls.Clear();

            AddLabel("Nome:", 20, 20);
            txtNomeCliente = AddTextbox(120, 20);

            AddLabel("Telefone:", 20, 60);
            txtTelefone = AddTextbox(120, 60);

            Button btnAdd = AddButton("Adicionar Cliente", 20, 110);
            btnAdd.Click += BtnAddCliente_Click;

            grid = AddGrid(20, 170);
            grid.DataSource = Clientes;
        }

        private void MostrarProducao()
        {
            painelConteudo.Controls.Clear();

            AddLabel("Data:", 20, 20);
            dtpData = new DateTimePicker();
            dtpData.SetBounds(120, 20, 200, 25);
            painelConteudo.Controls.Add(dtpData);

            AddLabel("Quantidade:", 20, 60);
            nudQtdProducao = new NumericUpDown();
            nudQtdProducao.SetBounds(120, 60, 80, 25);
            painelConteudo.Controls.Add(nudQtdProducao);

            Button btnAdd = AddButton("Registrar Produção", 20, 110);
            btnAdd.Click += BtnAddProducao_Click;

            grid = AddGrid(20, 170);
            grid.DataSource = Producoes;
        }

        private void MostrarRelatorios()
        {
            painelConteudo.Controls.Clear();

            Button b1 = AddButton("Estoque", 20, 20);
            Button b2 = AddButton("Produção", 150, 20);
            Button b3 = AddButton("Clientes", 280, 20);

            grid = AddGrid(20, 80);
            grid.DataSource = Produtos;

            b1.Click += delegate { grid.DataSource = Produtos; };
            b2.Click += delegate { grid.DataSource = Producoes; };
            b3.Click += delegate { grid.DataSource = Clientes; };
        }

        // ---------------------------
        // EVENTOS DE CLIQUE
        // ---------------------------
        private void BtnDashboard_Click(object sender, EventArgs e) { MostrarDashboard(); }
        private void BtnEstoque_Click(object sender, EventArgs e) { MostrarEstoque(); }
        private void BtnClientes_Click(object sender, EventArgs e) { MostrarClientes(); }
        private void BtnProducao_Click(object sender, EventArgs e) { MostrarProducao(); }
        private void BtnRelatorios_Click(object sender, EventArgs e) { MostrarRelatorios(); }

        private void BtnAddProduto_Click(object sender, EventArgs e)
        {
            double preco;

            if (!double.TryParse(txtPreco.Text, out preco))
            {
                MessageBox.Show("Preço inválido. Digite apenas números.");
                return;
            }

            Produtos.Add(new Produto
            {
                Nome = txtNomeProduto.Text,
                Categoria = txtCategoria.Text,
                Quantidade = (int)nudQuantidade.Value,
                Preco = preco
            });

            AtualizarGrid(Produtos);

            txtNomeProduto.Clear();
            txtCategoria.Clear();
            txtPreco.Clear();
            nudQuantidade.Value = 0;
        }

        private void BtnAddCliente_Click(object sender, EventArgs e)
        {
            Clientes.Add(new Cliente
            {
                Nome = txtNomeCliente.Text,
                Telefone = txtTelefone.Text
            });

            AtualizarGrid(Clientes);

            txtNomeCliente.Clear();
            txtTelefone.Clear();
        }

        private void BtnAddProducao_Click(object sender, EventArgs e)
        {
            Producoes.Add(new Producao
            {
                Data = dtpData.Value,
                Quantidade = (int)nudQtdProducao.Value
            });

            AtualizarGrid(Producoes);
            nudQtdProducao.Value = 0;
        }

        private void AtualizarGrid(object lista)
        {
            grid.DataSource = null;
            grid.DataSource = lista;
        }

        // ---------------------------
        // MÉTODOS AUXILIARES
        // ---------------------------
        private Label AddLabel(string texto, int x, int y)
        {
            Label lbl = new Label();
            lbl.Text = texto;
            lbl.ForeColor = Color.White;
            lbl.AutoSize = true;
            lbl.Location = new Point(x, y);
            painelConteudo.Controls.Add(lbl);
            return lbl;
        }

        private TextBox AddTextbox(int x, int y)
        {
            TextBox txt = new TextBox();
            txt.SetBounds(x, y, 150, 25);
            painelConteudo.Controls.Add(txt);
            return txt;
        }

        private Button AddButton(string texto, int x, int y)
        {
            Button btn = new Button();
            btn.Text = texto;
            btn.BackColor = Color.FromArgb(70, 40, 20);
            btn.ForeColor = Color.White;
            btn.SetBounds(x, y, 200, 35);
            btn.FlatStyle = FlatStyle.Flat;
            painelConteudo.Controls.Add(btn);
            return btn;
        }

        private DataGridView AddGrid(int x, int y)
        {
            DataGridView dg = new DataGridView();
            dg.SetBounds(x, y, 740, 350);
            dg.BackgroundColor = Color.White;
            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dg.AllowUserToAddRows = false;

            painelConteudo.Controls.Add(dg);
            return dg;
        }
    }
}
