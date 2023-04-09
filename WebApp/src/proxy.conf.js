const PROXY_CONFIG = [
  {
    context: [
      "/api/currency",
    ],
    target: "http://localhost:7265",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
