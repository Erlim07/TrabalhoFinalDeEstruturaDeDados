using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace caTrabalhoFinalED
{
    internal class Program
    {

        static void Main(string[] args)
        {
            ListaEncadeada<Cidade> listaComTodas = new ListaEncadeada<Cidade>();

            //adicionando as cidades
            Cidade Tupaciguara = new Cidade("Tupaciguara"); listaComTodas.insereInicio(Tupaciguara);
            Cidade Uberlandia = new Cidade("Uberlandia"); listaComTodas.insereInicio(Uberlandia);
            Cidade MonteAlegre = new Cidade("Monte Alegre de Minas"); listaComTodas.insereInicio(MonteAlegre);
            Cidade Itumbiara = new Cidade("Itumbiara"); listaComTodas.insereInicio(Itumbiara);
            Cidade Centralina = new Cidade("Centralina"); listaComTodas.insereInicio(Centralina);
            Cidade Capinopolis = new Cidade("Capinopolis"); listaComTodas.insereInicio(Capinopolis);
            Cidade Ituiutaba = new Cidade("Ituiutaba"); listaComTodas.insereInicio(Ituiutaba);
            Cidade Douradinhos = new Cidade("Douradinhos"); listaComTodas.insereInicio(Douradinhos);
            Cidade Araguari = new Cidade("Araguari"); listaComTodas.insereInicio(Araguari);
            Cidade Indianopolis = new Cidade("Indianopolis"); listaComTodas.insereInicio(Indianopolis);
            Cidade CascalhoRico = new Cidade("Cascalho Rico"); listaComTodas.insereInicio(CascalhoRico);
            Cidade Grupiara = new Cidade("Grupiara"); listaComTodas.insereInicio(Grupiara);
            Cidade EstreladoSul = new Cidade("Estrela do Sul"); listaComTodas.insereInicio(EstreladoSul);
            Cidade Romaria = new Cidade("Romaria"); listaComTodas.insereInicio(Romaria);
            Cidade SaoJuliana = new Cidade("São Juliana"); listaComTodas.insereInicio(SaoJuliana);

            //

            //regitrando conexões
            Tupaciguara.addConexao(Itumbiara, 55);
            Tupaciguara.addConexao(Uberlandia, 60);
            Tupaciguara.addConexao(MonteAlegre, 44);
            Uberlandia.addConexao(Araguari, 30);
            Uberlandia.addConexao(Romaria, 78);
            Uberlandia.addConexao(Indianopolis, 45);
            Uberlandia.addConexao(Douradinhos, 63);
            Uberlandia.addConexao(MonteAlegre, 60);
            MonteAlegre.addConexao(Douradinhos, 28);
            MonteAlegre.addConexao(Ituiutaba, 85);
            MonteAlegre.addConexao(Centralina, 75);
            Itumbiara.addConexao(Centralina, 20);
            Centralina.addConexao(Capinopolis, 40);
            Capinopolis.addConexao(Ituiutaba, 30);
            Ituiutaba.addConexao(Douradinhos, 90);
            Araguari.addConexao(CascalhoRico, 28);
            Araguari.addConexao(EstreladoSul, 34);
            Indianopolis.addConexao(SaoJuliana, 40);
            CascalhoRico.addConexao(Grupiara, 32);
            Grupiara.addConexao(EstreladoSul, 38);
            EstreladoSul.addConexao(Romaria, 27);
            Romaria.addConexao(SaoJuliana, 28);

            int entrada = chamadora();

            //parte de realmente perguntar o que quer e mostrar o caminho
            while (true)
            {

                if (entrada == 1)
                {
                    Console.WriteLine("Qual é a cidade de início da viagem:");
                    Cidade inicio = achaPeloNome(Console.ReadLine(), listaComTodas);
                    Console.WriteLine("Qual é a cidade de fim da viagem: ");
                    Cidade fim = achaPeloNome(Console.ReadLine(), listaComTodas);

                    //tags colocadas em todas as cidades
                    tagEmTodas(inicio, listaComTodas);
                    Cidade aux = fim;
                    while(aux != inicio)
                    {
                        Console.Out.NewLine = "";
                        Console.WriteLine(aux.Nome + "<-");
                        aux = aux.Tag.Previo;
                    }
                    Console.Out.NewLine = "\n";
                    Console.WriteLine(aux.Nome);
                    Console.WriteLine("A menor distância entre as cidades é de " + fim.Tag.Tamanho + " km");

                    limpaTagEExpansao(listaComTodas);

                    entrada = chamadora();

                }
                else
                    break;
            }
        }

        //função para colocar tags em todas as cidades
        static void tagEmTodas(Cidade inicio, ListaEncadeada<Cidade> listaDeTodas)
        {
            //colocando a tag na primeira cidade
            inicio.Tag = new Tag(0, null);
            
            //enquanto todas as cidades não estiverem expandidas
            while (!todasExpandidas(listaDeTodas))
            {
                //explora todas as cidades
                NoLista<Cidade> aux = listaDeTodas.Inicio;
                while(aux != null)
                {
                    //se a cidade já foi encontrada, 
                    if (aux.Info.Tag != null)
                    {
                        aux.Info.tagNasConexoes();
                    }

                    aux = aux.Posterior;
                }

            }
        }


        //checa se todas as cidades foram expandidas
        static bool todasExpandidas(ListaEncadeada<Cidade> listaDeTodas)
        {
            NoLista<Cidade> aux = listaDeTodas.Inicio;
            while(aux != null)
            {
                if (!aux.Info.Expandida)
                {
                    return false;
                }
                aux = aux.Posterior;
            }
            return true;
        }

        //limpa as tags de todas as cidades para uso posterior 
        static void limpaTagEExpansao(ListaEncadeada<Cidade> listaDeTodas)
        {
            NoLista<Cidade> aux = listaDeTodas.Inicio;
            while (aux != null)
            {
                aux.Info.Tag = null;
                aux.Info.Expandida = false;
                aux.Info.Visitada = false;
                aux = aux.Posterior;
            }
        }

        static Cidade achaPeloNome(string nome, ListaEncadeada<Cidade> listaDeTodas)
        {
            NoLista<Cidade> aux = listaDeTodas.Inicio;
            while (aux != null)
            {
                if(aux.Info.Nome == nome)
                {
                    return aux.Info;
                }
                aux = aux.Posterior;
            }
            return null;
        }

        static int chamadora()
        {
            Console.WriteLine("Escolha qual opção você deseja: ");
            Console.WriteLine("1- Definir um trajeto.");
            Console.WriteLine("2- Sair.");

            return Convert.ToInt32(Console.ReadLine());
        }
    }
}   
