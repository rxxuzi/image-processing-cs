## Gray Scale Image Processing ./rsc/Base.png save as ./rsc/GrayScale.png

## without cv2 Image Processing 

# img = cv2.imread('./rsc/Base.png')

# img_gray = toGray(img)

# img_gray = toGray(img)

# cv2.imwrite('./rsc/GrayScale.png', img_gray)


import numpy as np

def  toGray(img):
    height, width, channel = img.shape
    for i in range(height):
        img_gray = np.zeros((img.shape[0], img.shape[1]), dtype=np.uint8)
    for i in range(img.shape[0]):
        for j in range(img.shape[1]):
            img_gray[i][j] = int(img[i][j][0] * 0.11 + img[i][j][1] * 0.59 + img[i][j][2] * 0.3)
    return img_gray


