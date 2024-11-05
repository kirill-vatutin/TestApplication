namespace TestApplication.Domain.Shared;

public static class Errors
{
    public static class General
    {
        public static Error ValueIsInvalid(string? name = null)
        {
            string label = name ?? "value";
            return Error.Validation("value.is.invalid", $"{label} is invalid");
        }
        public static Error NotFound(Guid? id = null)
        {
            string forId = id == null ? "" : $" for Id '{id}'";
            return Error.Validation("record.not.found", $"record not found{forId}");
        }

        public static Error ValueIsRequired(string? name = null)
        {
            string label = name == null ? "" : " " + name + " ";
            return Error.Validation("length.is.invalid", $"invalid{label}length");
        }
    }

    public static class Item
    {
        public static Error AlreadyExist()
        {
            return Error.Validation("record.already.exist", $"Module already exist");
        }
    }
}
