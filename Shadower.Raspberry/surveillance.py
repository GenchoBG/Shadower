from picamera import PiCamera
from time import sleep
import requests
import os
import cloudinary
import cloudinary.uploader
import cloudinary.api
import uuid

# TODO: move out of repo 
cloudinary.config(
  cloud_name = 'dh1wcfcpm',  
  api_key = '881146448163242',  
  api_secret = 'MQJQOrdclvBUx6U4GbFOhJGYAjc'  
)

camera = PiCamera()

#camera.start_preview()
sleep(2)

pythonServerUrl = "http://83.228.90.116:80/getembeddings"
aspNetServerUrl = "http://shadowerweb.azurewebsites.net/Home/AddPost"

while True:
#for i in range(5):
    imagePath = f'./imagee.jpg'
    
    camera.capture(imagePath)
    
    data = {}
    files = {
        'face' : open(imagePath, 'rb')    
    }
    
    try:
        result = requests.post(pythonServerUrl, data=data, files=files)
    except:
        print("error posting to python api")
        continue
    
    embeddings = result.json()
    
    if len(embeddings) > 0:
        
        guid = str(uuid.uuid4())
        cloudinary_res = cloudinary.uploader.upload(imagePath, public_id = guid, folder="ad_images")
        
        link = cloudinary_res['secure_url']
        
        data = {
            'embeddings' : embeddings,
            'link' : link
        }        
        response = requests.post(aspNetServerUrl, data, files)
        
        print(response.text)
        
        #break
    
    os.remove(imagePath)
    
    sleep(1)
    
#camera.stop_preview()