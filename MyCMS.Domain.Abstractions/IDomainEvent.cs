﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCMS.Domain.Abstractions
{
    public interface IDomainEvent : INotification
    {
    }
}
