﻿using NorthWind.UseCasesPorts.CreateOrder;
using System;

namespace NorthWind.Presenters
{
    public class CreateOrderPresenter : ICreateOrderOutputPort,IPresenter<string>
    {
        public string Content { get; private set;}

        public Task Handle(int orderId)
        {
            Content = $"Order ID: {orderId}";
            return Task.CompletedTask;
        }
    }
}
