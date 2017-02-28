# XmlConfig
Simple configuration library that uses XML to persist data.

### Example Config

```<ConfigObject>

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

This config file can be read and modifed using a static object..

`Config.App.Name`
`Config.User.Age`

Write data simply

`Config.App.Name = "Major update!"`
    
