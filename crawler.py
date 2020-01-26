from facebook_scraper import get_posts
from face_detection import extract_faces, open_image
from face_recognition import get_embedding
import urllib
from PIL import Image
from io import BytesIO
from numpy import asarray
import requests
import numpy as np
from requests_html import HTMLSession

def addpost(link, image):
    embeddings = []
    faces = extract_faces(image)
    for face in faces:
        if face.shape[0] >= 70 and face.shape[1] >= 70:
            embeddings.append(get_embedding(face))

    if len(embeddings) == 0 or link == None:
        return
    print(np.array(embeddings).shape)
    API_ENDPOINT = "http://localhost:64205/Home/AddPost"
    data = {
        'link':link,
        'embeddings':embeddings
    }
    r = requests.post(url = API_ENDPOINT, data = data)
    print(r)

target = 'https://www.facebook.com/pg/clubilluzion/photos/'

def get_albums(target):
    session = HTMLSession()
    r = session.get(target)
    r.html.render()
    links = r.html.absolute_links

    albums = []
    for link in links:
        if 'tab=album&album_id=' in link:
            albums.append(link)

    return albums

target_album = 'https://www.facebook.com/pg/clubbiad/photos/?tab=album&album_id=10157825957381276'
albums = [target_album]

def get_images(album):
    index = 0
    images = []

    session = HTMLSession()
    page = session.get(album)
    page.html.render()
    a_tags = page.html.find('div._2eea a', first=False)
    for a_tag in a_tags:
        href = a_tag.attrs['href']
        if href != "#":
            href+='&theater'
            photosession = HTMLSession()
            photorequest = photosession.get(href)
            photorequest.html.render()

            imgs = photorequest.html.find('img', first=False)
            imgs = [image for image in imgs if not 'security' in image.attrs['src']]

            maxArea = -1
            maxImg = None
            for img in imgs[1:]:
                try:
                    area = int(img.attrs['width']) * int(img.attrs['height'])
                    if area > maxArea:
                        maxArea = area
                        maxImg = img
                except:
                    pass

            src = maxImg.attrs['src']
            file = urllib.request.urlopen(src)
            img = Image.open(file).convert('RGB')
            images.append((href, asarray(img)))
            img.save(f'{index}.jpg')
            index += 1

    return images


for link, image in get_images(target_album):
    addpost(link, image)
