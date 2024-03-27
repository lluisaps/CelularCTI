using System;
using System.Collections.Generic;
using CelularCTI.Model;
using CelularCTI.Model.Entidades;
using CelularCTI.Model.Suporte;
using Npgsql;

namespace CelularCTI.Model
{
    public static class Servico
    {

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
            a.Modelo = dtr["modelo"].ToString();

            a.Quantidade = (float)Convert.ToDouble(dtr["quantidade"]);
            a.Largura = (float)Convert.ToDouble(dtr["largura"]);
            a.Altura = (float)Convert.ToDouble(dtr["altura"]);
            a.Espessura = (float)Convert.ToDouble(dtr["espessura"]);
            a.Peso = (float)Convert.ToDouble(dtr["peso"]);
            a.Preco = (float)Convert.ToDecimal(dtr["preco"]);
            a.Desconto = (float)Convert.ToDecimal(dtr["desconto"]);
            a.Fabricante = ObjFabricante(ref dtr);

            return a;
        }

        public static Pedido ObjPedido(ref NpgsqlDataReader dtr)
        {
            Pedido ped = new Pedido();
            ped.Id_pedido = Convert.ToInt64(dtr["id_pedido"]);
            ped.DataHoraPedido = Convert.ToDateTime(dtr["datahorapedido"]);
            ped.Observacao = dtr["observacao"].ToString();

            ped.Aparelho = ObjAparelho(ref dtr);

            return ped;
        }



        public static void Salvar(Aparelho ap)
        {
            String sql;

            if (ap.Id_Aparelho == 0)
            {
                sql = "INSERT INTO aparelho " +
                    "(id_aparelho, id_fabricante, modelo, largura, altura, " +
                    "espessura, peso, quantidade, preco, desconto) VALUES (DEFAULT, " +
                    ap.Fabricante.Id_Fabricante + ",'" +
                    ap.Modelo + "'," +
                    ap.Largura + "," +
                    ap.Altura + "," +
                    ap.Espessura + "," +
                    ap.Peso + "," +
                    ap.Quantidade + "," +
                    ap.Preco + "," +
                    ap.Desconto + ")";
                ConnBanco.Executar(sql);

            }
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
                    "desconto = " + ap.Desconto.ToString().Replace(',', '.' ) + " " +
                    "WHERE id_aparelho = " + ap.Id_Aparelho;
                ConnBanco.Executar(sql);
            }
        }

        public static void Salvar(Fabricante fab)
        {
            string sql;
            if (fab.Id_Fabricante == 0)
            {
                sql = "insert into fabricante (nome, observacao) values ";
                sql += "'" + fab.Nome + "', ";
                sql += "'" + fab.Observacao + "')";
                ConnBanco.Executar(sql);
            }
            else
            {
                sql = "update fabricante set ";
                sql += "   nome = '" + fab.Nome + "', ";
                sql += "   observacao = '" + fab.Observacao + "' ";
                sql += "where id_fabricante = " + fab.Id_Fabricante;
            }
        }


        public static List<Aparelho> BuscarAparelho()
        {
            string sql;
            List<Aparelho> aparelho = new List<Aparelho>();

            sql = "SELECT aparelho.*, fabricante.* " +
                       "FROM aparelho INNER JOIN fabricante " +
                        "ON aparelho.id_fabricante = fabricante.id_fabricante " +
                  "ORDER BY fabricante.nome, aparelho.modelo";

            NpgsqlDataReader dtr = ConnBanco.Selecionar(sql);
            while (dtr.Read())
                aparelho.Add(ObjAparelho(ref dtr));
            dtr.Close();

            return aparelho;
        }

        public static Aparelho BuscarAparelho(Int64 id)
        {
            string sql;
            Aparelho aparelho = new Aparelho();

            sql = "SELECT aparelho.*, fabricante.* " +
                "FROM aparelho INNER JOIN fabricante " +
                "ON aparelho.id_fabricante = fabricante.id_fabricante " +
                "WHERE aparelho.id_aparelho = " + id;

            NpgsqlDataReader dtr = ConnBanco.Selecionar(sql);
            dtr.Read();
            aparelho = ObjAparelho(ref dtr);
            dtr.Close();

            return aparelho;
        }

        public static List<Aparelho> BuscarAparelho(string modelo)
        {
            string sql;
            List<Aparelho> aparelho = new List<Aparelho>();

            sql = "SELECT aparelho.*, fabricante.* " +
                "FROM aparelho INNER JOIN fabricante " +
                "ON aparelho.id_fabricante = fabricante.id_fabricante " +
                "WHERE aparelho.modelo ILIKE '%" + modelo + "%' " +
                "ORDER BY aparelho.modelo";

            NpgsqlDataReader dtr = ConnBanco.Selecionar(sql);
            while (dtr.Read())
                aparelho.Add(ObjAparelho(ref dtr));
            dtr.Close();

            return aparelho;
        }

        public static List<Aparelho> BuscarAparelho(decimal precoMin, decimal precoMax)
        {
            string sql;
            List<Aparelho> aparelho = new List<Aparelho>();
            List<object> param = new List<object>();

            sql = "SELECT aparelho.*, fabricante.* " +
                "FROM aparelho INNER JOIN fabricante " +
                "ON aparelho.id_fabricante = fabricante.id_fabricante " +
                "WHERE aparelho.preco BETWEEN @1 AND @2 " +
                "ORDER BY aparelho.preco";

            param.Add(precoMin);
            param.Add(precoMax);

            NpgsqlDataReader dtr = ConnBanco.Selecionar(sql, param);
            while (dtr.Read())
                aparelho.Add(ObjAparelho(ref dtr));
            dtr.Close();

            return aparelho;
        }

        public static List<Aparelho> BuscarAparelho(Fabricante f)
        {
            List<Aparelho> aparelho = new List<Aparelho>();
            NpgsqlDataReader dtr = ConnBanco.Selecionar(
                "SELECT * FROM aparelho " +
                "INNER JOIN fabricante ON fabricante.id_fabricante = aparelho.id_fabricante " +
                "WHERE fabricante.id_fabricante=" + f.Id_Fabricante);
            while (dtr.Read())
                aparelho.Add(ObjAparelho(ref dtr));
            dtr.Close();
            return aparelho;
        }


        public static List<Fabricante> BuscarFabricante()
        {
            List<Fabricante> fabricante = new List<Fabricante>();
            NpgsqlDataReader dtr = ConnBanco.Selecionar("SELECT * FROM fabricante order by nome");
            while (dtr.Read())
                fabricante.Add(ObjFabricante(ref dtr));
            dtr.Close();
            return fabricante;
        }

        public static Fabricante BuscarFabricante(Int64 id)
        {
            string sql;
            Fabricante fab = new Fabricante();
            sql = "select * from fabricante";
            sql += "   where id_fabricante = " + id;

            NpgsqlDataReader dtr = ConnBanco.Selecionar(sql);

            dtr.Read();
            fab = ObjFabricante(ref dtr);
            dtr.Close();

            return fab;
        }

        public static Pedido FazerPedido(Aparelho ap)
        {
            Pedido p = new Pedido();

            try
            {
                p.Aparelho = ap;
                p.DataHoraPedido = DateTime.Now;

                String sql = "INSERT INTO pedido (id_aparelho, datahorapedido) " +
                            "VALUES (" + ap.Id_Aparelho +
                            ", '" + p.DataHoraPedido.ToString("yyyy-MM-dd hh:mm:ss") +
                            "')";

                ConnBanco.Executar(sql);

                ap.Quantidade--;
                Salvar(ap);

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Não foi ´possível efetivar o pedido  da compra!"
                                                + "\n\nMais detalhes: " + ex.Message);
            }
            return p;
        }
    }
}
