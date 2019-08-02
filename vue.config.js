const path = require("path");
let assetsDir = "dist";

module.exports = {
  devServer: {
    https: false
  },
  outputDir: path.resolve(__dirname, "./IslbTransfers/IslbTransfers/wwwroot/"),
  configureWebpack: {
    output: {
      filename: assetsDir + "/[name].js",
      chunkFilename: assetsDir + "/[name].js"
    }
  },
  chainWebpack: config => {
    if (config.plugins.has("extract-css")) {
      const extractCSSPlugin = config.plugin("extract-css");
      extractCSSPlugin &&
        extractCSSPlugin.tap(() => [
          {
            filename: assetsDir + "/[name].css",
            chunkFilename: assetsDir + "/[name].css"
          }
        ]);
    }
  }
}
