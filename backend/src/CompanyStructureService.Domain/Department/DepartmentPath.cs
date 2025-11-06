using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStructureService.Domain.Department
{
    public record DepartmentPath
    {
        public string Value { get; }
        private DepartmentPath(string value)
        {
            Value = value;
        }

        public static DepartmentPath Create(string path)
        {
            return new DepartmentPath(path.ToLower());
        }

        // Собираем путь из родительского пути и идентификатора текущего отдела
        public static DepartmentPath BuildFrom(DepartmentIdentifier identifier, DepartmentPath? parentPath = null)
        {
            // Если нет родителя, то это - корневой отдел. Будет просто идентификатор
            if (parentPath == null)
                return Create(identifier.Value);

            // Если родитель есть — добавляем текущий идентификатор через точку
            return Create($"{parentPath.Value}.{identifier.Value}");
        }
    }
}
