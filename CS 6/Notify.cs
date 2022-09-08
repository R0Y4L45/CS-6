
namespace Notify;

internal class Notify
{
    public Guid id;
    public String? text, notifyFromUser;
    public DateTime? date;

    public Notify(string? text, string? notifyFromUser, DateTime? date)
    {
        id = Guid.NewGuid();
        this.text = text;
        this.notifyFromUser = notifyFromUser;
        this.date = date;
    }

    public override string ToString()
    {
        return $@"ID -->  {id}
Text -->  {text}
Date -->  {date}
User_name -->  {notifyFromUser}";
    }

}

