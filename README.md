# Shadower
A web-based AI-powered application, which scans and analyzes photo/video content published on social media and then detects as well as identifies faces in order to help locating missing individuals.
# Face Detection in action
Example of the face-detection Neural Network extracting faces ready to be fed to the face-embedding Neural Network. <br/> <br/>
Input image:<br/>
![input image](./Shadower.ML/test/test.png)
<br/>
<br/>
Output faces:<br/>
![output image 0](./Shadower.ML/out/0.jpg)
![output image 1](./Shadower.ML/out/1.jpg)
![output image 2](./Shadower.ML/out/2.jpg)
![output image 3](./Shadower.ML/out/3.jpg)
![output image 4](./Shadower.ML/out/4.jpg)
![output image 5](./Shadower.ML/out/5.jpg)
# Face Comparison
Example of using the Euclidean distance between the image embeddings of the faces from the face-embedding Neural Network in order to determine weather both pictures contain the face of the same person. High distance indicates different faces, while low distance indicates similar faces. <br/><br/>
![bobi](./Shadower.ML/out/bobiface.jpg)
![marian2](./Shadower.ML/out/marianface2.jpg) <br/>
Distance: 15.416445 - NOT the same person <br/> <br/>
![marian1](./Shadower.ML/out/marianface1.jpg)
![marian2](./Shadower.ML/out/marianface2.jpg) <br/>
Distance: 8.533536 - The same person <br/>
# Demo
Check out a demo of the application.

<a href="https://www.youtube.com/watch?v=SKNt9P7tloM">![demo](https://i.imgur.com/yYL3blb.png)</a>
