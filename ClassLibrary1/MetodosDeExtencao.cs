using Dominio.Models;
using SuperCore.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCore
{
    static class MetodosDeExtencao
    {
        public static Endereco ExtraiaEndereco(this PessoaModel pessoa)
        {
            var enderedo = pessoa.Endereco;
            if(enderedo != null)
            {
                return new Endereco()
                { 
                    Id = pessoa.Id,
                    CEP = enderedo.CEP,
                    Cidade = enderedo.Cidade,
                    Quarto = enderedo.Quarto,
                    Rua = enderedo.Rua
                };
            }
            return null;
        }
        public static Empresa ExtraiaEmpresa(this PessoaModel pessoa)
        {
            var empresa = pessoa.Empresa;
            if(empresa != null)
            {
                return new Empresa()
                { 
                    BS = empresa.BS,
                    Id = pessoa.Id,
                    NomeEmresa = empresa.NomeEmresa,
                    CatchPhrase = empresa.CatchPhrase
                };
            }
            return null;
        }
        public static Coordenadas ExtraiaCoordenadas(this PessoaModel pessoa)
        {
            var localizacao = pessoa.Endereco?.Localizacao;
            if (localizacao != null)
            {
                return new Coordenadas()
                {
                    Id = pessoa.Id,
                    Latitude = localizacao.Latitude,
                    Longitude = localizacao.Longitude
                };
            }
            return null;
        }
    }
}
