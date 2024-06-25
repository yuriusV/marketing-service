resource "kubernetes_deployment" "customer_api" {
  metadata {
    name = "customer-api"
    namespace = "default"
  }

  spec {
    replicas = 2

    selector {
      match_labels = {
        app = "customer-api"
      }
    }

    template {
      metadata {
        labels = {
          app = "customer-api"
        }
      }

      spec {
        container {
          image = "gcr.io/${var.project_id}/customer-api:latest"
          name  = "customer-api"

          env {
            name  = "POSTGRES_CONNECTION_STRING"
            value = module.cloud_sql_customer.connection_name
          }
        }
      }
    }
  }
}

resource "kubernetes_service" "customer_api" {
  metadata {
    name = "customer-api"
  }

  spec {
    selector = {
      app = "customer-api"
    }

    ports {
      port = 80
      target_port = 8080
    }
  }
}
