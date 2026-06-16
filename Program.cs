List<Customer> customers = new List<Customer>();

string choice = "";

while (choice != "0")
{
    PrintMenu();

    choice = Input();

    HandleChoice(choice, customers);
}

static void PrintMenu()
{
    Console.WriteLine("==== Customer Manager ====");
    Console.WriteLine("1. Add Customer");
    Console.WriteLine("2. Show Customers");
    Console.WriteLine("3. Search Customer");
    Console.WriteLine("4. Update Customer");
    Console.WriteLine("5. Delete Customer");
    Console.WriteLine("0. Exit");
    Console.WriteLine();
    Console.Write("Choose option: ");
}

static string Input()
{
    string? selected = Console.ReadLine();

    if (selected == null)
    {
        return "";
    }

    return selected;
}

static void HandleChoice(string choice, List<Customer> customers)
{
    switch (choice)
    {
        case "0":
            Console.WriteLine("Goodbye");
            break;

        case "1":
            AddCustomer(customers);
            break;

        case "2":
            ShowCustomers(customers);
            break;

        case "3":
            SearchCustomer(customers);
            break;

        case "4":
            UpdateCustomer(customers);
            break;

        case "5":
            DeleteCustomer(customers);
            break;

        default:
            Console.WriteLine("Invalid option");
            break;
    }

    Console.WriteLine();
}

static void AddCustomer(List<Customer> customers)
{
    Console.Write("Enter customer name: ");
    string name = Input();

    Console.Write("Enter customer phone: ");
    string phone = Input();

    Customer customer = new Customer() ;
     customer.Id = customers.Count + 1;
     customer.Name = name;
     customer.Phone = phone;
    

    customers.Add(customer);

    Console.WriteLine("Customer added successfully");
}

static void ShowCustomers(List<Customer> customers)
{
    if (customers.Count == 0)
    {
        Console.WriteLine("No customers found");
        return;
    }

    Console.WriteLine("Customers:");

    foreach (Customer customer in customers)
    {
        Console.WriteLine($"Id: {customer.Id}, Name: {customer.Name}, Phone: {customer.Phone}");
    }
}

static void SearchCustomer(List<Customer> customers)
{
    Console.Write("Enter customer name to search: ");
    string searchName = Input();

    bool found = false;

    foreach (Customer customer in customers)
    {
        if (customer.Name.ToLower().Contains(searchName.ToLower()))
        {
            Console.WriteLine($"Id: {customer.Id}, Name: {customer.Name}, Phone: {customer.Phone}");
            found = true;
        }
    }

    if (!found)
    {
        Console.WriteLine("Customer not found");
    }
}

static void UpdateCustomer(List<Customer> customers)
{
    Console.Write("Enter customer id to update: ");
    string inputId = Input();

    bool isNumber = int.TryParse(inputId, out int id);

    if (!isNumber)
    {
        Console.WriteLine("Invalid id");
        return;
    }

    Customer? customerToUpdate = null;

    foreach (Customer customer in customers)
    {
        if (customer.Id == id)
        {
            customerToUpdate = customer;
            break;
        }
    }

    if (customerToUpdate == null)
    {
        Console.WriteLine("Customer not found");
        return;
    }

    Console.Write("Enter new name: ");
    string newName = Input();

    Console.Write("Enter new phone: ");
    string newPhone = Input();

    customerToUpdate.Name = newName;
    customerToUpdate.Phone = newPhone;

    Console.WriteLine("Customer updated successfully");
}

static void DeleteCustomer(List<Customer> customers)
{
    Console.Write("Enter customer id to delete: ");
    string inputId = Input();

    bool isNumber = int.TryParse(inputId, out int id);

    if (!isNumber)
    {
        Console.WriteLine("Invalid id");
        return;
    }

    Customer? customerToDelete = null;

    foreach (Customer customer in customers)
    {
        if (customer.Id == id)
        {
            customerToDelete = customer;
            break;
        }
    }

    if (customerToDelete == null)
    {
        Console.WriteLine("Customer not found");
        return;
    }

    customers.Remove(customerToDelete);

    Console.WriteLine("Customer deleted successfully");
}

class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Phone { get; set; } = "";
}