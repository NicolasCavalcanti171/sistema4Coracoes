using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_3_PI_DS
{
    public partial class Form1 : Form
    {
    
        // BANCO DE DADOS

        private List<Produto> Produtos = new List<Produto>();
        private List<Cliente> Clientes = new List<Cliente>();
        private List<Producao> Producoes = new List<Producao>();

        // COMPONENTES
        private Panel painelMenu;
        private Panel painelConteudo;
        private DataGridView grid;

        private TextBox txtNomeProduto, txtCategoria, txtPeso, txtPreco;
        private TextBox txtNomeCliente, txtTelefone;
        private NumericUpDown nudQuantidade, nudQtdProducao;
        private DateTimePicker dtpData;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.ClientSize = new Size(1100, 650);
            this.Text = "ERP 4 Corações - Sistema de Gestão";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CriarInterface();
            CarregarProdutosPDF();
        }

        // MODELOS (CORRETOS — ESSA É A CLASSE QUE O GRID DEVE LER)

        private class Produto
        {
            public string Nome { get; set; }
            public string Categoria { get; set; }
            public string Peso { get; set; }
            public double Preco { get; set; }
            public int Quantidade { get; set; }
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


        // COLOCAR OS PRODUTOS

        private void CarregarProdutosPDF()
        {
            Produtos.Add(new Produto { Nome = "Gourmet 100% Arábica - Clara 250g", Categoria = "Arábica", Peso = "250 g", Preco = 42.90 });
            Produtos.Add(new Produto { Nome = "Gourmet 100% Arábica - Clara 500g", Categoria = "Arábica", Peso = "500 g", Preco = 79.90 });
            Produtos.Add(new Produto { Nome = "Gourmet 100% Arábica - Clara 1kg", Categoria = "Arábica", Peso = "1 kg", Preco = 97.90 });

            Produtos.Add(new Produto { Nome = "Gourmet 100% Arábica - ES 250g", Categoria = "Arábica", Peso = "250 g", Preco = 45.90 });
            Produtos.Add(new Produto { Nome = "Gourmet 100% Arábica - ES 500g", Categoria = "Arábica", Peso = "500 g", Preco = 84.90 });
            Produtos.Add(new Produto { Nome = "Gourmet 100% Arábica - ES 1kg", Categoria = "Arábica", Peso = "1 kg", Preco = 104.90 });

            Produtos.Add(new Produto { Nome = "Gourmet Arábica - Orgânico 250g", Categoria = "Orgânico", Peso = "250 g", Preco = 57.90 });
            Produtos.Add(new Produto { Nome = "Gourmet Arábica - Orgânico 500g", Categoria = "Orgânico", Peso = "500 g", Preco = 109.90 });
            Produtos.Add(new Produto { Nome = "Gourmet Arábica - Orgânico 1kg", Categoria = "Orgânico", Peso = "1 kg", Preco = 134.90 });

            Produtos.Add(new Produto { Nome = "Gourmet Dark Roast 250g", Categoria = "Torrado", Peso = "250 g", Preco = 47.90 });
            Produtos.Add(new Produto { Nome = "Gourmet Dark Roast 500g", Categoria = "Torrado", Peso = "500 g", Preco = 89.90 });
            Produtos.Add(new Produto { Nome = "Gourmet Dark Roast 1kg", Categoria = "Torrado", Peso = "1 kg", Preco = 112.90 });

            Produtos.Add(new Produto { Nome = "Intenso - Cápsulas (10)", Categoria = "Cápsulas", Peso = "50 g", Preco = 37.90 });
            Produtos.Add(new Produto { Nome = "Intenso - Cápsulas (30)", Categoria = "Cápsulas", Peso = "150 g", Preco = 109.90 });
            Produtos.Add(new Produto { Nome = "Intenso - Cápsulas (50)", Categoria = "Cápsulas", Peso = "250 g", Preco = 127.90 });

            Produtos.Add(new Produto { Nome = "Rituais Mogiana 250g", Categoria = "Especial", Peso = "250 g", Preco = 62.90 });
            Produtos.Add(new Produto { Nome = "Rituais Mogiana 500g", Categoria = "Especial", Peso = "500 g", Preco = 119.90 });
            Produtos.Add(new Produto { Nome = "Rituais Mogiana 1kg", Categoria = "Especial", Peso = "1 kg", Preco = 142.90 });
        }


        // INTERFACE

        private void CriarInterface()
        {
            this.BackColor = Color.FromArgb(90, 55, 35);

            painelMenu = new Panel();
            painelMenu.Size = new Size(220, this.Height);
            painelMenu.BackColor = Color.FromArgb(60, 35, 20);
            this.Controls.Add(painelMenu);

            CriarBotaoMenu("Dashboard", 20, BtnDashboard_Click);
            CriarBotaoMenu("Estoque", 80, BtnEstoque_Click);
            CriarBotaoMenu("Clientes", 140, BtnClientes_Click);
            CriarBotaoMenu("Produção", 200, BtnProducao_Click);
            CriarBotaoMenu("Relatórios", 260, BtnRelatorios_Click);

            painelConteudo = new Panel();
            painelConteudo.Location = new Point(220, 0);
            painelConteudo.Size = new Size(this.Width - 220, this.Height);
            painelConteudo.BackColor = Color.FromArgb(130, 90, 55);
            this.Controls.Add(painelConteudo);

            MostrarDashboard();
        }

        private void CriarBotaoMenu(string texto, int top, EventHandler acao)
        {
            Button btn = new Button();
            btn.Text = texto;
            btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btn.SetBounds(20, top, 180, 45);
            btn.BackColor = Color.FromArgb(90, 50, 30);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.FromArgb(255, 204, 153);
            btn.FlatAppearance.BorderSize = 2;

            btn.Click += acao;
            painelMenu.Controls.Add(btn);
        }


        // TELAS

        private void MostrarDashboard()
        {
            painelConteudo.Controls.Clear();

            Label titulo = new Label();
            titulo.Text = "ERP 4 Corações - Bem-vindo!";
            titulo.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            titulo.ForeColor = Color.White;
            titulo.AutoSize = true;
            titulo.Location = new Point(30, 30);
            painelConteudo.Controls.Add(titulo);
        }

        private void MostrarEstoque()
        {
            painelConteudo.Controls.Clear();

            AddLabel("Nome:", 20, 20);
            txtNomeProduto = AddTextbox(150, 20);

            AddLabel("Categoria:", 20, 60);
            txtCategoria = AddTextbox(150, 60);

            AddLabel("Peso:", 20, 100);
            txtPeso = AddTextbox(150, 100);

            AddLabel("Preço:", 20, 140);
            txtPreco = AddTextbox(150, 140);

            AddLabel("Quantidade:", 20, 180);
            nudQuantidade = new NumericUpDown();
            nudQuantidade.SetBounds(150, 180, 100, 30);
            painelConteudo.Controls.Add(nudQuantidade);

            Button btnAdd = AddButton("Adicionar Produto", 20, 230);
            btnAdd.Click += BtnAddProduto_Click;

            grid = AddGrid(20, 300);
            AtualizarGrid(Produtos);
        }

        private void MostrarClientes()
        {
            painelConteudo.Controls.Clear();

            AddLabel("Nome:", 20, 20);
            txtNomeCliente = AddTextbox(150, 20);

            AddLabel("Telefone:", 20, 60);
            txtTelefone = AddTextbox(150, 60);

            Button btnAdd = AddButton("Adicionar Cliente", 20, 110);
            btnAdd.Click += BtnAddCliente_Click;

            grid = AddGrid(20, 170);
            AtualizarGrid(Clientes);
        }

        private void MostrarProducao()
        {
            painelConteudo.Controls.Clear();

            AddLabel("Data:", 20, 20);
            dtpData = new DateTimePicker();
            dtpData.SetBounds(150, 20, 200, 30);
            painelConteudo.Controls.Add(dtpData);

            AddLabel("Quantidade:", 20, 60);
            nudQtdProducao = new NumericUpDown();
            nudQtdProducao.SetBounds(150, 60, 100, 30);
            painelConteudo.Controls.Add(nudQtdProducao);

            Button btnAdd = AddButton("Registrar Produção", 20, 110);
            btnAdd.Click += BtnAddProducao_Click;

            grid = AddGrid(20, 170);
            AtualizarGrid(Producoes);
        }

        private void MostrarRelatorios()
        {
            painelConteudo.Controls.Clear();

            Button b1 = AddButton("Estoque", 20, 20);
            Button b2 = AddButton("Produção", 200, 20);
            Button b3 = AddButton("Clientes", 380, 20);

            grid = AddGrid(20, 80);
            AtualizarGrid(Produtos);

            b1.Click += (s, e) => AtualizarGrid(Produtos);
            b2.Click += (s, e) => AtualizarGrid(Producoes);
            b3.Click += (s, e) => AtualizarGrid(Clientes);
        }


        // AÇÕES

        private void BtnAddProduto_Click(object sender, EventArgs e)
        {
            double preco;
            if (!double.TryParse(txtPreco.Text, out preco))
            {
                MessageBox.Show("Digite um preço válido.");
                return;
            }

            Produtos.Add(new Produto
            {
                Nome = txtNomeProduto.Text,
                Categoria = txtCategoria.Text,
                Peso = txtPeso.Text,
                Preco = preco,
                Quantidade = (int)nudQuantidade.Value
            });

            AtualizarGrid(Produtos);
        }

        private void BtnAddCliente_Click(object sender, EventArgs e)
        {
            Clientes.Add(new Cliente
            {
                Nome = txtNomeCliente.Text,
                Telefone = txtTelefone.Text
            });

            AtualizarGrid(Clientes);
        }

        private void BtnAddProducao_Click(object sender, EventArgs e)
        {
            Producoes.Add(new Producao
            {
                Data = dtpData.Value,
                Quantidade = (int)nudQtdProducao.Value
            });

            AtualizarGrid(Producoes);
        }


        // NAVEGAÇÃO ENTRE TELAS

        private void BtnDashboard_Click(object sender, EventArgs e) => MostrarDashboard();
        private void BtnEstoque_Click(object sender, EventArgs e) => MostrarEstoque();
        private void BtnClientes_Click(object sender, EventArgs e) => MostrarClientes();
        private void BtnProducao_Click(object sender, EventArgs e) => MostrarProducao();
        private void BtnRelatorios_Click(object sender, EventArgs e) => MostrarRelatorios();



        // GRID COM FORMATAÇÃO (Preço aparecendo!)

        private void AtualizarGrid(object lista)
        {
            grid.DataSource = null;
            grid.DataSource = lista;

            if (grid.Columns.Contains("Preco"))
            {
                grid.Columns["Preco"].DefaultCellStyle.Format = "C2";
                grid.Columns["Preco"].HeaderText = "Preço (R$)";
            }
        }


        // COMPONENTES AUXILIARES

        private Label AddLabel(string texto, int x, int y)
        {
            Label lbl = new Label();
            lbl.Text = texto;
            lbl.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lbl.ForeColor = Color.White;
            lbl.AutoSize = true;
            lbl.Location = new Point(x, y);
            painelConteudo.Controls.Add(lbl);
            return lbl;
        }

        private TextBox AddTextbox(int x, int y)
        {
            TextBox txt = new TextBox();
            txt.SetBounds(x, y, 180, 30);
            txt.Font = new Font("Segoe UI", 11);
            painelConteudo.Controls.Add(txt);
            return txt;
        }

        private Button AddButton(string texto, int x, int y)
        {
            Button btn = new Button();
            btn.Text = texto;
            btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btn.SetBounds(x, y, 180, 40);
            btn.BackColor = Color.FromArgb(90, 50, 30);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.FromArgb(255, 204, 153);
            btn.FlatAppearance.BorderSize = 2;
            painelConteudo.Controls.Add(btn);
            return btn;
        }

        private DataGridView AddGrid(int x, int y)
        {
            DataGridView dg = new DataGridView();
            dg.SetBounds(x, y, 820, 300);
            dg.BackgroundColor = Color.White;
            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dg.AllowUserToAddRows = false;
            painelConteudo.Controls.Add(dg);
            return dg;
        }
    }
}