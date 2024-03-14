using CelularCTI.Model.Entidades;
using CelularCTI.Model.Suporte;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelularCTI.Model
{
    public class Servico
    {
        //Métodos que vão criar e atribuir os dados para os objetos que representam as entidades

        public static Fabricante ObjFabricante(ref NpgsqlDataReader dtr)
        {
            Fabricante fab = new Fabricante();
            fab.Id_Fabricante = Convert.ToInt64(dtr["id_fabricante"]);
            fab.Nome = dtr["nome"].ToString();
            fab.Observacao = dtr["observacao"].ToString();
            return fab;
        }

        private static Aparelho ObjAparelho(ref NpgsqlDataReader dtr)
        {
            Aparelho a = new Aparelho();
            a.Id_Aparelho = Convert.ToInt64(dtr["id_aparelho"]);
            a.Modelo = (String)dtr["modelo"];
            a.Quantidade = (double)dtr["quantidade"];
            a.Largura = (double)(dtr["largura"]);
            a.Altura = (double)(dtr["altura"]);
            a.Espessura = (double)(dtr["espessura"]);
            a.Peso = (double)(dtr["peso"]);
            a.Preco = (decimal)(dtr["preco"]);
            a.Desconto = (decimal)(dtr["desconto"]);

            a.Fabricante = ObjFabricante(ref dtr);

            return a;
        }

        public static Pedido ObjPedido(ref NpgsqlDataReader dr)
        {
            Pedido ped = new Pedido();
            ped.Id_pedido = Convert.ToInt64(dr["id_pedido"]);
            ped.DataHoraPedido = Convert.ToDateTime(dr["datahorapedido"]);
            ped.Observacao = dr["observacao"].ToString();

            ped.Aparelho = ObjAparelho(ref dr);

            return ped;
        }

        public static void Salvar(Fabricante fab)
        {
            string sql;
            if(fab.Id_Fabricante == 0)
            {
                sql = "insert into fabricante(nome,observacao) values";
                sql += "'" + fab.Nome + "',";
                sql += "'" + fab.Observacao + "')";
                ConexaoBanco.Executar(sql);
            }
            else
            {
                sql = "update fabricante set";
                sql += " nome '" + fab.Nome + "' , ";
                sql += "obsrvacao ='" + fab.Observacao + "'";
                sql += "where id_fabricante = " + fab.Id_Fabricante;

            }
        }


        public static Aparelho BuscarAparelho(Int64 id)
        {
            string sql;
            Aparelho aparelho = new Aparelho();
            sql = "SELECT aparelho.*, fabricante.* " +
                "FROM aparelho INNER JOIN fabricante " +
                "ON aparelho.id_fabricante = fabricante.id_fabricante " +
                "WHERE aparelho.id_aparelho = " + id;

            NpgsqlDataReader dtr = ConexaoBanco.Selecionar(sql);
            dtr.Read();
            aparelho = ObjAparelho(ref dtr);
            dtr.Close(); 
            //para fechar o data reader para liberar da memoria 
            
            //nao pode ter dois data reader na memoria
            return aparelho;

        }

        public static Fabricante BuscarFabricante (Int64 id)
        {
            string sql;
            Fabricante fab = new Fabricante();
            sql = "select * from fabricante ";
            sql += "where id_fabricante =" + id;
            NpgsqlDataReader dtr = ConexaoBanco.Selecionar(sql);
            dtr.Read();
            fab = ObjFabricante(ref dtr);
            dtr.Close();
            return fab;

        }

        public static List<Aparelho> BuscarAparelho(string model)
        {
            string sql;
            List<Aparelho> aparelho = new List<Aparelho>();

            sql = "SELECT aparelho.*, fabricante.* " +
                "FROM aparelho INNER JOIN fabricante " +
                "ON aparelho.modelo = fabricante.id_fabricante " +
                "WHERE aparelho.modelo ILIKE '%" + model + "%' " +
                "ORDER BY aparelho.modelo";
            // o que o ILIKE faz? nao é case sensitive 

           

            return aparelho;

        }


        public static List<Aparelho> BuscarAparelho(decimal precoMin, decimal precoMax)
        {
            string sql;
            List<Aparelho> aparelho = new List<Aparelho>();
            List<object> param = new List<object>();

            sql = "SELECT aparelho.*, fabricante.* " +
                "FROM aparelho INNER JOIN fabricante " +
                "ON aparelho.modelo = fabricante.id_fabricante " +
                "WHERE aparelho.preco BETWEEN @1 AND @2 " + 
                "ORDER BY aparelho.preco";
            // o que o ILIKE faz? nao é case sensitive 

            param.Add(precoMin);
            param.Add(precoMax);

            NpgsqlDataReader dtr = ConexaoBanco.Selecionar(sql);
            while (dtr.Read())
            {
                aparelho.Add(ObjAparelho(ref dtr));
            }
            dtr.Close();

            return aparelho;

        }

       public static List<Fabricante> TodsFabricantes()
        {
            List<Fabricante> fabricantes = new List<Fabricante>();
            NpgsqlDataReader dtr = ConexaoBanco.Selecionar("SELECT * FROM fabricante order by nome");
            while (dtr.Read()) { 
            fabricantes.Add(ObjFabricante(ref dtr));
                
            }

            dtr.Close();
            return fabricantes; 

        }


        public static Pedido FazerPedido(Aparelho ap)
        {
            Pedido p = new Pedido();

            try
            {
                p.Aparelho = ap;
                p.DataHoraPedido = DateTime.Now;
                string sql = "INSERT INTO pedido (id_aparelho, datahorapedido)" +
                    "VALUES(" + ap.Id_Aparelho +
                    ", '" + p.DataHoraPedido.ToString("yyyy-MM-dd hh:mm:ss") + "')";

                ConexaoBanco.Executar(sql);
                ap.Quantidade--;
                Salvar(ap);

                //Gerar comissao
                
            }catch (Exception ex)
            {
                throw new ApplicationException("Não foi possivel efetivar o pedido  da " + "\n\n Mais detalhes:" + ex.Message);
            }
            return p;
        }






        public static void Salvar(Aparelho ap)
        {
            String sql;

            if (ap.Id_Aparelho == 0)
            {
            //se o id é zero o usuario nao colocou nada na tela
                sql = "INSERT INTO aparelho " +
                    "(id_fabricante, modelo, largura, altura, espessura, peso, quantidade, preco, desconto) VALUES (DEFAULT, " +
                    ap.Fabricante.Id_Fabricante + ",'" + ap.Modelo + "',"
                        + ap.Largura + "," + ap.Altura + "," + ap.Espessura + ","
                        + ap.Peso + "," + ap.Quantidade + "," + ap.Preco + "," + ap.Desconto + ")";
                ConexaoBanco.Executar(sql);

            } //1'or 'true' 1 or 'true'
            else
            {
                sql = "UPDATE aparelho SET " +
                        "id_fabricante = " + ap.Fabricante.Id_Fabricante + "," +
                        "modelo = '" + ap.Modelo + "'," +
                        "largura = " + ap.Largura.ToString().Replace(',', '.') + "," +
                        "altura = " + ap.Altura.ToString().Replace(',', '.') + "," +
                        "espessura = " + ap.Espessura.ToString().Replace(',', '.') + "," +
                        "peso = " + ap.Peso.ToString().Replace(',', '.') + "," +
                        "quantidade = " + ap.Quantidade + "," +
                        "preco = " + ap.Preco.ToString().Replace(',', '.') + "," +
                        "desconto = " + ap.Desconto.ToString().Replace(',', '.') + " " +
                        "WHERE id_aparelho = " + ap.Id_Aparelho;
                ConexaoBanco.Executar(sql);

                //replace manipula string 
            }
        }

      
    }
}
