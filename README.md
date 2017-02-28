# XmlConfig
Simple configuration library that uses XML to persist data.

### Example Config
XmlConfig starts with a configuration definition. This tells XmlConfig what properties it should load into the dynamic object.

```
<ConfigObject>
    <App>
      <Name type="System.String">Testing App</Name>
      <Version type="System.String">0.1</Version>
    </App>
    
    <User>
      <Name type="System.String">Josh</Name>
      <Age type="System.Int16">22</Age>
      <SignupYear>2017</SignupYear>
    </User>
</ConfigObject>
```

### Reading and Writing Basics

Accessing properties from XmlConfig is super simple.

```
Console.WriteLine(Config.App.Name);
Output: Testing App
```

No type casting required! XmlConfig already knows the type of your data and keeps a record of the type in the config file.

```
short userAge = Config.User.Age

if (userAge > 18)
    Console.WriteLine("Have a drink!");

Output: Have a drink!
```

Write data as simply as you read it!

```
Config.App.Name = "Major update!";
Config.User.Age = 17;

// Save to disk
Config.Save();

short userAge = Config.User.Age;
if (userAge < 18)
    Console.WriteLine("Maybe next year..");

Output: aybe next year..;
```

Note in order to save data to disk the config definition needs to define the property first!

    
