﻿namespace FirstAPI.Models.DTOs
{
    public class LoginResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } =string.Empty;

        public string Token { get; set; } = string.Empty;

    }
}
