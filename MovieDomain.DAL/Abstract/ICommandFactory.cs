﻿namespace MovieDomain.DAL.Abstract
{
    public interface ICommandFactory
    {
        T CreateCommand<T>(ISession session);
    }
}
