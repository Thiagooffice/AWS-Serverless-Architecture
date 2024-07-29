using Amazon.Lambda.SQSEvents;
using Amazon.Lambda.TestUtilities;
using Amazon.Runtime.Internal.Transform;
using ECommerceLambda.Domain.Models;
using System.Text.Json;

namespace AprovarPedidoLambda.Tests
{
    public class FunctionTest
    {
        [Fact]
        public async void Deve_salvar_um_pedido_com_sucesso()
        {
            var pedido = new Pedido
            {
                Cliente = new Cliente
                {
                    Nome = "Thyago",
                    Documento = "12145478799",
                    Email = "thyago@email.com",
                    Endereco = new Endereco
                    {
                        Cidade = "Rio de Janeiro",
                        Estado = "RJ",
                        Logradouro = "Rua das Laranjas",
                        Numero = 123,
                        Complemento = "apt 123"
                    },
                },
                PedidoId = Guid.NewGuid(),
                StatusPedido = StatusPedidoEnum.AGUARDANDO_PAGAMENTO,
                ItensPedido = new List<ItemPedido>
                {
                    new ItemPedido
                    {
                        ProdutoId = 1,
                        Quantidade = 2,
                        ValorUnitario = 50
                    }
                }
            };

            var input = new SQSEvent
            {
                Records = new List<SQSEvent.SQSMessage>
                 {
                     new SQSEvent.SQSMessage
                     {
                         Body = JsonSerializer.Serialize(pedido),
                         Attributes = new Dictionary<string, string>()
                         {
                             { "ApproximateReceiveCount", "1" }
                         }
                     }
                 }
            };

            var context = new TestLambdaContext
            {
                Logger = new TestLambdaLogger()
            };

            var function = new Function();
            await function.FunctionHandler(input, context);

            // assert
        }
    }
}