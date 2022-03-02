# Code Challenges WebApi

## REQUEST
`
POST https://localhost:7206/challenge/multiline
`

```
form-data
{
    "output": "*\n**\n***",
    "content": "basic for loop",
    "degree": 0
}
```

## RESPONSE
```
basic for loop
Beginner
*
**
***
****
```