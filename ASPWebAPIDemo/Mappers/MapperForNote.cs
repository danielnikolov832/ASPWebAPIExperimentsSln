using ASPWebAPIDemo.DAL.DAOs;
using ASPWebAPIDemo.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASPWebAPIDemo.Mappers
{
    public class MapperForNote : Mapper
    {
        public MapperForNote()
        {
            Config.NewConfig<NoteDao, Note>()
                .ConstructUsing(dao => new Note(dao.Name));

            Config.NewConfig<StringNotePropertyDao, StringNoteProperty>()
               .ConstructUsing(dao => new StringNoteProperty(dao.Name, dao.get_value));
        }
    }
}
