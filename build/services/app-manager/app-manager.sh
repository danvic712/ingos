COMMIT_ID=$(git rev-parse --short HEAD)

#REGISTRY=https://docker.pkg.github.com/danvic712/ingos
IMAGE=ingos/app-manager

VERSION=$(cat version) 
TAG=$(echo "$VERSION" | awk -F. -v OFS=. '{$NF++;print}')
echo "$TAG" > version

if [ "$COMMIT_ID" == "" ]; then
  IMAGE_TAG=$IMAGE:$TAG
else
  IMAGE_TAG=$IMAGE:$TAG-$COMMIT_ID
fi 

docker build -t "$IMAGE_TAG" --build-arg commit-id="$COMMIT_ID" ../../../services/app-manager/Dockerfile
# docker push "$IMAGE_TAG"