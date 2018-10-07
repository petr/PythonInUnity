import json

from UnityEngine import *

data = {
    'test': 'abds',
    1: '1500',
}

Debug.Log(json.dumps(data))


