import json
from UnityEngine import *
from jsonschema import validate, ValidationError

Debug.Log(json_to_check)

schema = {
     "type" : "object",
     "properties" : {
         "price" : {"type" : "string"},
         "name" : {"type" : "string"},
     }
}

try:
    validate(json.loads(json_to_check), schema)
    Debug.Log(json_to_check + " is valid")
except ValidationError as e:
    Debug.LogError(json_to_check + " is invalid: " + e.message)