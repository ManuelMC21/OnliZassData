using onlizas.Entities;

namespace onlizas.Utils;

public static class SupplierTypeToString
{
    public static string ToString(int index)
    {
        return index == 0 ? "Persona" : "Empresa";
    }

}