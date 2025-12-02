using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace Sistema_3_PI_DS
{
    public class ProdutoModel
    {
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Peso { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
    }

    public class ClienteModel
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
    }

    public class ProducaoModel
    {
        public DateTime Data { get; set; }
        public int Quantidade { get; set; }
        public string NomeProduto { get; set; }
    }

    public partial class Form1 : Form
    {
        List<ProdutoModel> Produtos = new List<ProdutoModel>();
        List<ClienteModel> Clientes = new List<ClienteModel>();
        List<ProducaoModel> Producoes = new List<ProducaoModel>();

        Panel painelMenu;
        Panel painelConteudo;
        DataGridView grid;

        TextBox txtNomeProduto, txtCategoria, txtPeso, txtPreco;
        NumericUpDown nudQuantidade;

        TextBox txtNomeCliente, txtTelefone;

        NumericUpDown nudQtdProducao;
        DateTimePicker dtpData;
        ComboBox cmbProdutoProducao;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void InitializeComponent()
        {
            this.ClientSize = new Size(1100, 650);
            this.Text = "ERP 4 Corações - Sistema de Gestão";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CriarInterfaceInicial();
            CarregarProdutosPadrao();
        }

        private void CarregarProdutosPadrao()
        {
            Produtos.Add(new ProdutoModel { Nome = "GOURMET 100% ARÁBICA – TORRA CLARA", Categoria = "Gourmet", Peso = "250 g", Preco = 42.90 });
            Produtos.Add(new ProdutoModel { Nome = "GOURMET 100% ARÁBICA – TORRA CLARA", Categoria = "Gourmet", Peso = "500 g", Preco = 79.90 });
            Produtos.Add(new ProdutoModel { Nome = "GOURMET 100% ARÁBICA – TORRA CLARA", Categoria = "Gourmet", Peso = "1 kg", Preco = 97.90 });

            Produtos.Add(new ProdutoModel { Nome = "GOURMET 100% ARÁBICA – ESPÍRITO SANTO", Categoria = "Gourmet", Peso = "250 g", Preco = 45.90 });
            Produtos.Add(new ProdutoModel { Nome = "GOURMET 100% ARÁBICA – ESPÍRITO SANTO", Categoria = "Gourmet", Peso = "500 g", Preco = 84.90 });
            Produtos.Add(new ProdutoModel { Nome = "GOURMET 100% ARÁBICA – ESPÍRITO SANTO", Categoria = "Gourmet", Peso = "1 kg", Preco = 104.90 });

            Produtos.Add(new ProdutoModel { Nome = "GOURMET 100% ARÁBICA – ORGÂNICO", Categoria = "Gourmet", Peso = "250 g", Preco = 57.90 });
            Produtos.Add(new ProdutoModel { Nome = "GOURMET 100% ARÁBICA – ORGÂNICO", Categoria = "Gourmet", Peso = "500 g", Preco = 109.90 });
            Produtos.Add(new ProdutoModel { Nome = "GOURMET 100% ARÁBICA – ORGÂNICO", Categoria = "Gourmet", Peso = "1 kg", Preco = 134.90 });

            Produtos.Add(new ProdutoModel { Nome = "GOURMET – DARK ROAST", Categoria = "Torra Escura", Peso = "250 g", Preco = 47.90 });
            Produtos.Add(new ProdutoModel { Nome = "GOURMET – DARK ROAST", Categoria = "Torra Escura", Peso = "500 g", Preco = 89.90 });
            Produtos.Add(new ProdutoModel { Nome = "GOURMET – DARK ROAST", Categoria = "Torra Escura", Peso = "1 kg", Preco = 112.90 });

            Produtos.Add(new ProdutoModel { Nome = "INTENSO – CÁPSULAS DE ALUMÍNIO", Categoria = "Cápsulas", Peso = "10 cápsulas (50 g)", Preco = 37.90 });
            Produtos.Add(new ProdutoModel { Nome = "INTENSO – CÁPSULAS DE ALUMÍNIO", Categoria = "Cápsulas", Peso = "30 cápsulas (150 g)", Preco = 109.90 });
            Produtos.Add(new ProdutoModel { Nome = "INTENSO – CÁPSULAS DE ALUMÍNIO", Categoria = "Cápsulas", Peso = "50 cápsulas (250 g)", Preco = 127.90 });

            Produtos.Add(new ProdutoModel { Nome = "RITUAIS – MOGIANA PAULISTA", Categoria = "Rituais", Peso = "250 g", Preco = 62.90 });
            Produtos.Add(new ProdutoModel { Nome = "RITUAIS – MOGIANA PAULISTA", Categoria = "Rituais", Peso = "500 g", Preco = 119.90 });
            Produtos.Add(new ProdutoModel { Nome = "RITUAIS – MOGIANA PAULISTA", Categoria = "Rituais", Peso = "1 kg", Preco = 142.90 });
        }

        private void CriarInterfaceInicial()
        {
            this.Controls.Clear();
            this.BackColor = Color.FromArgb(80, 45, 25);

            Label lblTitulo = new Label()
            {
                Text = "ERP 4 Corações",
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(380, 50)
            };
            this.Controls.Add(lblTitulo);

            Label lblUsuario = new Label()
            {
                Text = "Usuário:",
                Font = new Font("Segoe UI", 12),
                ForeColor = Color.White,
                Location = new Point(330, 180),
                AutoSize = true
            };
            this.Controls.Add(lblUsuario);

            TextBox txtUsuario = new TextBox()
            {
                Name = "txtUsuarioLogin",
                Font = new Font("Segoe UI", 12),
                Location = new Point(410, 175),
                Width = 220
            };
            this.Controls.Add(txtUsuario);

            Label lblSenha = new Label()
            {
                Text = "Senha:",
                Font = new Font("Segoe UI", 12),
                ForeColor = Color.White,
                Location = new Point(330, 230),
                AutoSize = true
            };
            this.Controls.Add(lblSenha);

            TextBox txtSenha = new TextBox()
            {
                Name = "txtSenhaLogin",
                Font = new Font("Segoe UI", 12),
                Location = new Point(410, 225),
                Width = 220,
                PasswordChar = '•'
            };
            this.Controls.Add(txtSenha);

            Button btnEntrar = new Button()
            {
                Text = "Entrar",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                BackColor = Color.FromArgb(150, 90, 50),
                ForeColor = Color.White,
                Location = new Point(410, 280),
                Size = new Size(220, 42)
            };
            btnEntrar.Click += (s, e) =>
            {
                string usuario = txtUsuario.Text.Trim();
                string senha = txtSenha.Text.Trim();

                if (string.Equals(usuario, "admin", StringComparison.OrdinalIgnoreCase) && senha == "1234")
                {
                    this.Controls.Clear();
                    CriarInterfaceSistema();
                    AtualizarGridProdutos();
                }
                else
                {
                    MessageBox.Show("Usuário ou senha incorretos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            this.Controls.Add(btnEntrar);
        }

        private void CriarInterfaceSistema()
        {
            this.BackColor = Color.FromArgb(90, 55, 35);

            painelMenu = new Panel()
            {
                Size = new Size(220, this.ClientSize.Height),
                BackColor = Color.FromArgb(60, 35, 20),
                Location = new Point(0, 0),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left
            };
            this.Controls.Add(painelMenu);

            CriarBotaoMenu("Dashboard", 20, BtnDashboard_Click);
            CriarBotaoMenu("Estoque", 80, BtnEstoque_Click);
            CriarBotaoMenu("Clientes", 140, BtnClientes_Click);
            CriarBotaoMenu("Produção", 200, BtnProducao_Click);
            CriarBotaoMenu("Relatórios", 260, BtnRelatorios_Click);

            painelConteudo = new Panel()
            {
                Location = new Point(220, 0),
                Size = new Size(this.ClientSize.Width - 220, this.ClientSize.Height),
                BackColor = Color.FromArgb(130, 90, 55),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };
            this.Controls.Add(painelConteudo);

            MostrarDashboard();
        }

        private void CriarBotaoMenu(string texto, int top, EventHandler acao)
        {
            Button btn = new Button()
            {
                Text = texto,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Location = new Point(20, top),
                Size = new Size(180, 45),
                BackColor = Color.FromArgb(90, 50, 30),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btn.FlatAppearance.BorderColor = Color.FromArgb(255, 204, 153);
            btn.FlatAppearance.BorderSize = 2;
            btn.Click += acao;
            painelMenu.Controls.Add(btn);
        }

        private void MostrarDashboard()
        {
            painelConteudo.Controls.Clear();

            Label titulo = new Label()
            {
                Text = "ERP 4 Corações - Bem-vindo!",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(30, 30)
            };
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

            Button btnExcluir = AddButton("Excluir Produto", 220, 230);
            btnExcluir.Click += BtnExcluirProduto_Click;

            grid = AddGrid(20, 300);
            AtualizarGridProdutos();
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
            AtualizarGridClientes();
        }

        private void MostrarProducao()
        {
            painelConteudo.Controls.Clear();

            AddLabel("Data:", 20, 20);
            dtpData = new DateTimePicker();
            dtpData.SetBounds(150, 20, 200, 30);
            painelConteudo.Controls.Add(dtpData);

            AddLabel("Produto:", 20, 60);
            cmbProdutoProducao = new ComboBox();
            cmbProdutoProducao.SetBounds(150, 60, 350, 30);
            cmbProdutoProducao.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbProdutoProducao.Items.AddRange(Produtos.Select(p => p.Nome).ToArray());

            if (cmbProdutoProducao.Items.Count > 0)
                cmbProdutoProducao.SelectedIndex = 0;

            painelConteudo.Controls.Add(cmbProdutoProducao);


            AddLabel("Quantidade:", 20, 100);
            nudQtdProducao = new NumericUpDown();
            nudQtdProducao.SetBounds(150, 100, 100, 30);
            nudQtdProducao.Maximum = 10000;
            painelConteudo.Controls.Add(nudQtdProducao);

            Button btnAdd = AddButton("Registrar Produção", 20, 150);
            btnAdd.Click += BtnAddProducao_Click;

            grid = AddGrid(20, 210);
            AtualizarGridProducoes();
        }

        private void MostrarRelatorios()
        {
            painelConteudo.Controls.Clear();

            Button b1 = AddButton("Estoque", 20, 20);
            Button b2 = AddButton("Produção", 200, 20);
            Button b3 = AddButton("Clientes", 380, 20);

            grid = AddGrid(20, 80);
            AtualizarGridProdutos();

            b1.Click += (s, e) => AtualizarGridProdutos();
            b2.Click += (s, e) => AtualizarGridProducoes();
            b3.Click += (s, e) => AtualizarGridClientes();
        }

        private void BtnDashboard_Click(object sender, EventArgs e) => MostrarDashboard();
        private void BtnEstoque_Click(object sender, EventArgs e) => MostrarEstoque();
        private void BtnClientes_Click(object sender, EventArgs e) => MostrarClientes();
        private void BtnProducao_Click(object sender, EventArgs e) => MostrarProducao();
        private void BtnRelatorios_Click(object sender, EventArgs e) => MostrarRelatorios();

        private void BtnAddProduto_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtPreco.Text, out double preco))
            {
                MessageBox.Show("Digite um preço válido.");
                return;
            }

            Produtos.Add(new ProdutoModel
            {
                Nome = txtNomeProduto.Text,
                Categoria = txtCategoria.Text,
                Peso = txtPeso.Text,
                Preco = preco,
                Quantidade = (int)nudQuantidade.Value
            });

            AtualizarGridProdutos();
        }

        private void BtnExcluirProduto_Click(object sender, EventArgs e)
        {
            if (grid == null || grid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um produto para excluir.");
                return;
            }

            int index = grid.SelectedRows[0].Index;
            if (index >= 0 && index < Produtos.Count)
                Produtos.RemoveAt(index);

            AtualizarGridProdutos();
        }

        private void BtnAddCliente_Click(object sender, EventArgs e)
        {
            Clientes.Add(new ClienteModel { Nome = txtNomeCliente.Text, Telefone = txtTelefone.Text });
            AtualizarGridClientes();
        }

        private void BtnAddProducao_Click(object sender, EventArgs e)
        {
            if (cmbProdutoProducao.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione um produto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nudQtdProducao.Value <= 0)
            {
                MessageBox.Show("A quantidade deve ser maior que zero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string produtoSelecionado = cmbProdutoProducao.SelectedItem.ToString();

            Producoes.Add(new ProducaoModel
            {
                NomeProduto = produtoSelecionado,
                Data = dtpData.Value,
                Quantidade = (int)nudQtdProducao.Value
            });

            AtualizarGridProducoes();
        }

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

        private void AtualizarGridProdutos()
        {
            if (grid == null) grid = AddGrid(20, 300);
            grid.DataSource = null;
            grid.DataSource = Produtos;
            if (grid.Columns.Contains("Preco"))
                grid.Columns["Preco"].DefaultCellStyle.Format = "C2";
        }

        private void AtualizarGridClientes()
        {
            if (grid == null) grid = AddGrid(20, 170);
            grid.DataSource = null;
            grid.DataSource = Clientes;
        }

        private void AtualizarGridProducoes()
        {
            if (grid == null) grid = AddGrid(20, 170);
            grid.DataSource = null;
            grid.DataSource = Producoes;
        }
    }
}