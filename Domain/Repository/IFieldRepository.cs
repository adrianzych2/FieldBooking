﻿using Domain.Models;

namespace Domain.Repository
{

    public interface IFieldRepository
    {
        void AddField(FieldDto field);
        FieldDto GetField(int id);
        List<FieldDto> GetAllField();
        void RemoveField(int id);
    }
}