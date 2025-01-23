﻿using FluentValidation.Results;

namespace ItakaShoppy.Backend.Common
{
    public class Response<T>
    {
        public T Data { get; set; }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}
