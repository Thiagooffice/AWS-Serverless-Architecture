﻿using ECommerceLambda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprovarPedidoLambda.Services
{
    public interface IMessageService
    {
        Task SendMessage(Pedido pedido);
    }
}
