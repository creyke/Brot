# Brot
Command line Brotli compressor and decompressor

# Installation
`dotnet tool install -g brot`

# Compressing
Compress a string into bytes and encode it into a base64 string:

`brot foo` outputs `CwGAZm9vAw==`

# Decompressing
Convert a base64 string into bytes and decompress it back to the original string:

`brot CwGAZm9vAw==` outputs `foo`
