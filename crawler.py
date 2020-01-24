from facebook_scraper import get_posts
from face_detection import extract_faces
from face_recognition import get_embedding
import urllib
from PIL import Image
from io import BytesIO
from numpy import asarray
import requests
import numpy as np


def addpost(link, image):
    faces = extract_faces(image)
    embeddings = [get_embedding(face) for face in faces]
    print(np.array(embeddings).shape)

    if len(embeddings) == 0 or link == None:
        return

    API_ENDPOINT = "http://localhost:64205/Home/AddPost"
    data = {
        'link':link,
        'embeddings':embeddings
    }
    r = requests.post(url = API_ENDPOINT, data = data)
    print(r)

index = 0
for post in get_posts('clubilluzion', pages=15):
    print()
    try:
        if post['post_url'] == None or post['image'] == None:
            continue

        print(post['post_url'])
        print(post['image'])
        file = urllib.request.urlopen(post['image'])
        img = Image.open(file).convert('RGB')
        img.save(f'{index}.jpg')
        index += 1
        img = asarray(img)



        print(img.shape)

        addpost(post['post_url'], img)

    except urllib.error.HTTPError:
        print('HTTPError')
    #faces = extract_faces(img)
    #embeddings = [get_embedding(im) for im in image]
