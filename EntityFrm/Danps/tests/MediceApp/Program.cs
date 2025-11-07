using System;
using System.Collections.Generic;
using System.Linq;

namespace MediceApp
{
    class Program
    {
        static void Main(string[] args)
        {

            TestaUm();
            Console.WriteLine("Hello World!");
        } 
        public static Produto[] Produtos = new Produto[] {
            new Produto("DOLAMIN FLEX                    ", "clonixinato de lisina + cloridrato de ciclobenzaprina", "125mg + 5mg", 12),
            new Produto("VENZER                          ", "candesartana cilexetila", "32mg", 30),
            new Produto("VENZER                          ", "candesartana cilexetila", "32mg", 60),
            new Produto("CARDILOL                        ", "carvedilol", "12,5mg", 30),
            new Produto("TYLENOL DC                      ", "paracetamol + cafeína", " 500mg + 65mg", 30),
            new Produto("OMEPRAMIX                       ", "omeprazol + claritromicina + amoxicilina", "20mg + 500mg + 500mg", 30),
            new Produto("CELESTONE SOLUSPAN              ","acetato de betametasona + fosfato dissódico de betametasona", " 3mg/mL + 3,945mg/mL", 60)
        };

        public static void TestaUm()
        {
            var pedido = Pedido.PedidoFactory.NovoPedidoRascunho(Guid.NewGuid());
            var produto = Produtos[0];

            var item = new PedidoItem(produto.Id, produto.DescricaoFormatada(), 10, 45.53m, produto.Embalagem);
            pedido.AdicionarItem(item);

            produto = Produtos[2];
            item = new PedidoItem(produto.Id, produto.DescricaoFormatada(), 3, 55.60m, produto.Embalagem);
            pedido.AdicionarItem(item);

            produto = Produtos[3];
            item = new PedidoItem(produto.Id, produto.DescricaoFormatada(), 1, 125m, produto.Embalagem);
            pedido.AdicionarItem(item);

            pedido.FinalizarPedido(DateTime.Parse("2023-01-01"));
            var receita = new Receita(Guid.NewGuid());
            receita.AdicionarPedido(pedido);

            Console.WriteLine($"Nome                      \t\t\tQuantidadePorDia\tDataNovaCompra");
            foreach (var med in receita.MedicamentoItems)
            {
                Console.WriteLine($"{med.ToString()}");
            }
            var medicamento = new Medicamento(item.ProdutoNome, 120, 120, DateTime.Now, FrequenciaPorUnidade.NovoPorDia(2));
            receita.AdicionarItem(medicamento);


            Console.WriteLine($"NovaCompra\n\nNome                     \t\t\tQuantidadePorDia\tDataNovaCompra");
            foreach (var med in receita.MedicamentoItems)
            {
                Console.WriteLine($"{med.ToString()}");
            }
        }
    }
    public class Produto
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Concentracao { get; private set; }
        public int Embalagem { get; private set; }

        protected Produto()
        {
        }

        public string DescricaoFormatada()
        {
            return $"{Nome} ({Concentracao})";
        }

        public Produto(string nome, string descricao, string concentracao, int embalagem)
        {
            Nome = nome;
            Descricao = descricao;
            Concentracao = concentracao;
            Embalagem = embalagem;
        }

    }

    public class PedidoItem
    {
        public Guid Id { get; private set; }
        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public string ProdutoNome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public int Embalagem { get; private set; }
        public Pedido Pedido { get; set; }

        public PedidoItem(Guid produtoId, string produtoNome, int quantidade, decimal valorUnitario, int embalagem)
        {
            ProdutoId = produtoId;
            ProdutoNome = produtoNome;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            Embalagem = embalagem;
        }

        protected PedidoItem()
        {
        }

        internal void AssociarPedido(Guid pedidoId)
        {
            PedidoId = pedidoId;
        }

        public decimal CalcularValor()
        {
            return Quantidade * ValorUnitario;
        }

        internal void AdicionarUnidades(int unidades)
        {
            Quantidade += unidades;
        }

        internal void AtualizarUnidades(int unidades)
        {
            Quantidade = unidades;
        }
    }

    public enum PedidoStatus
    {
        Rascunho,
        Iniciado,
        Pago,
        Cancelado
    }


    public class Pedido
    {
        public Guid Id { get; private set; }
        public int Codigo { get; private set; }
        public Guid ClienteId { get; private set; }
        public decimal Desconto { get; private set; }
        public decimal ValorTotal { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public PedidoStatus PedidoStatus { get; private set; }

        private readonly List<PedidoItem> _pedidoItems;
        public IReadOnlyCollection<PedidoItem> PedidoItems => _pedidoItems;

        public Pedido(Guid clienteId, decimal valorTotal)
        {
            ClienteId = clienteId;
            ValorTotal = valorTotal;
            _pedidoItems = new List<PedidoItem>();
        }

        protected Pedido()
        {
            _pedidoItems = new List<PedidoItem>();
        }

        public void AdicionarItem(PedidoItem item)
        {
            item.AssociarPedido(Id);

            item.CalcularValor();
            _pedidoItems.Add(item);

            CalcularValorPedido();
        }

        public void CalcularValorPedido()
        {
            ValorTotal = PedidoItems.Sum(p => p.CalcularValor());
        }

        public void AtualizarUnidades(PedidoItem item, int unidades)
        {
            item.AtualizarUnidades(unidades);
            AtualizarItem(item);
        }

        public void AtualizarItem(PedidoItem item)
        {
            item.AssociarPedido(Id);

            var itemExistente = PedidoItems.FirstOrDefault(p => p.ProdutoId == item.ProdutoId);

            if (itemExistente == null) throw new Exception("O item não pertence ao pedido");

            _pedidoItems.Remove(itemExistente);
            _pedidoItems.Add(item);

            CalcularValorPedido();
        }

        public void TornarRascunho()
        {
            PedidoStatus = PedidoStatus.Rascunho;
        }

        public void IniciarPedido()
        {
            PedidoStatus = PedidoStatus.Iniciado;
        }

        public void FinalizarPedido(DateTime dataProcessamento)
        {
            DataCadastro = dataProcessamento;
            PedidoStatus = PedidoStatus.Pago;
        }

        public void CancelarPedido()
        {
            PedidoStatus = PedidoStatus.Cancelado;
        }

        public static class PedidoFactory
        {
            public static Pedido NovoPedidoRascunho(Guid clienteId)
            {
                var pedido = new Pedido
                {
                    ClienteId = clienteId,
                };

                pedido.TornarRascunho();
                return pedido;
            }
        }
    }

    public enum Frequencia
    {
        Hora,
        Diaria,
        semanal,
        Custom
    }
    public class FrequenciaPorUnidade
    {   
        public Frequencia Frequencia { get; internal set; } 
        public int Intervalo { get; internal set; }
        public int Quantidade { get; internal set; }
        public int QuantidadePorDia { get; private set; }

        public FrequenciaPorUnidade(int quantidadePorDia)
        {
            QuantidadePorDia = quantidadePorDia; 
        }

        protected FrequenciaPorUnidade(Frequencia frequencia, int intervalo, int quantidade)
        {
            Frequencia = frequencia;
            Intervalo = intervalo;
            Quantidade = quantidade;
        }

        public static FrequenciaPorUnidade NovoPorHora(int intervalo, int quantidade)
        {
            var comprimidos = (24 / intervalo) * quantidade;
            var pedido = new FrequenciaPorUnidade(Frequencia.Hora, intervalo, quantidade);
            pedido.QuantidadePorDia = comprimidos;
            return pedido;
        }
        public static FrequenciaPorUnidade NovoPorDia(int quantidade)
        {            
            var pedido = new FrequenciaPorUnidade(Frequencia.Diaria, 24, quantidade);
            pedido.QuantidadePorDia = quantidade;
            return pedido;
        }
    }
    public class Medicamento
    {
        public string Nome { get; internal set; }
        public int Quantidade { get; internal set; }
        public decimal Total { get; internal set; }
        public DateTime DataCadastro { get; internal set; }
        public DateTime DataNovaCompra{ get; internal set; }
        public FrequenciaPorUnidade Frequencia { get; private set; }
        public int DiasTratamento{ get; internal set; }

        public Medicamento(string nome, int quantidade, decimal total, DateTime dataCadastro, FrequenciaPorUnidade frequencia)
        {
            Nome = nome;            
            Total = total;
            Frequencia = frequencia;
            AtualizarUnidades(quantidade, dataCadastro);
        } 
        internal void AdicionarUnidades(int unidades, DateTime dataCadastro)
        {
            this.Quantidade += unidades;
            this.DataCadastro = dataCadastro;
            CalcularNovaCompra();
        }

        private void CalcularNovaCompra()
        {
            this.DiasTratamento = Quantidade / Frequencia.QuantidadePorDia;
            DataNovaCompra = DataCadastro.AddDays(DiasTratamento);
        }

        internal void AtualizarUnidades(int unidades, DateTime dataCadastro)
        {
            Quantidade = unidades;
            DataCadastro = dataCadastro;
            CalcularNovaCompra();
        }
        
        public override string ToString()
        {
            return $"{Nome}\t\t\t{Frequencia.QuantidadePorDia}\t\t\t\t{DataNovaCompra}";
        }

    }

    public class Receita
    {
        private readonly List<Medicamento> _medicamentoItems;
        public IReadOnlyCollection<Medicamento> MedicamentoItems => _medicamentoItems;

        public Guid ClienteId { get; set; }

        public Receita(Guid clienteId)
        {
            ClienteId = clienteId;
            _medicamentoItems = new List<Medicamento>();
        }
        public void AdicionarPedido(Pedido pedido)
        {
            
            foreach (var item in pedido.PedidoItems)
            {
                var frequencia = FrequenciaPorUnidade.NovoPorDia(1);
                var medicamento = new Medicamento(item.ProdutoNome, item.Embalagem, pedido.ValorTotal, pedido.DataCadastro, frequencia);
                AdicionarItem(medicamento);
            }
        }


        public bool MedicamentoExistente(Medicamento item)
        {
            return _medicamentoItems.Any(p => p.Nome == item.Nome);
        }

        public void AdicionarItem(Medicamento item)
        {
            if (MedicamentoExistente(item))
            {
                var itemExistente = _medicamentoItems.FirstOrDefault(p => p.Nome == item.Nome);
                DebitarEstoque(itemExistente);
                itemExistente.AdicionarUnidades(item.Quantidade, item.DataCadastro);
                item = itemExistente;

                _medicamentoItems.Remove(itemExistente);
            }
            _medicamentoItems.Add(item);
        }

        private void DebitarEstoque(Medicamento itemExistente)
        {
            var diasCompra = (DateTime.Now - itemExistente.DataCadastro).Days;
            if (diasCompra > 0)
            {
                itemExistente.Quantidade -= itemExistente.Frequencia.QuantidadePorDia * diasCompra;
                if (itemExistente.Quantidade < 0) itemExistente.Quantidade = 0;
            }
        }

        public void AtualizarItem(Medicamento item)
        {
            var itemExistente = MedicamentoItems.FirstOrDefault(p => p.Nome == item.Nome);
            if (itemExistente == null) throw new Exception("O Medicamento não pertence à receita");
            _medicamentoItems.Remove(itemExistente);
            _medicamentoItems.Add(item);
        }
    }

}
