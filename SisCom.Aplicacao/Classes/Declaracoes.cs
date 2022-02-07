﻿using AutoMapper;
using Funcoes.Interfaces;
using Funcoes.Notifications;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Classes
{
    public static class Declaracoes
    {
        public static Notifier Notifier = new Notifier();
        public static MeuDbContext dbContext;
        public static MapperConfiguration configuration;
        public static Mapper mapper;

        public static string Aplicacao_Nome = "Sistema Comercial";

        public static int CampoNome_Caracteres = 100;
        public enum Navegar
        {
            Primeiro,
            Anterior,
            Atual,
            Proximo,
            Ultimo
        }
    }

    public static class Texto
    {
        public static string Mensagem_Fabricante_Remover = "Deseja remover o fabricante [Param01]?";
        public static string Mensagem_Grupo_NaoSelecionado = "Não foi selecionado nenhum grupo!";
        public static string Mensagem_Grupo_Remover = "Deseja remover o grupo [Param01]?";
    }

    public class Notifier : INotifier
    {
        public List<Notification> GetNotifications()
        {
            throw new NotImplementedException();
        }

        public void Handle(Notification notification)
        {
            CaixaMensagem.Informacao(notification.Key);
        }

        public void Handle(string notification)
        {
            CaixaMensagem.Informacao(notification);
        }

        public bool HasNotification()
        {
            throw new NotImplementedException();
        }
    }
}
