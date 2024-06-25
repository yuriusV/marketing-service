resource "kubernetes_deployment" "campaign_api" {
  metadata {
    name = "campaign-api"
    namespace = "default"
  }

  spec {
    replicas = 2

    selector {
      match_labels = {
        app = "campaign-api"
      }
    }

    template {
      metadata {
        labels = {
          app = "campaign-api"
        }
      }

      spec {
        container {
          image = "gcr.io/${var.project_id}/campaign-api:latest"
          name  = "campaign-api"

          env {
            name  = "POSTGRES_CONNECTION_STRING"
            value = module.cloud_sql_campaign.connection_name
          }
        }
      }
    }
  }
}

resource "kubernetes_service" "campaign_api" {
  metadata {
    name = "campaign-api"
  }

  spec {
    selector = {
      app = "campaign-api"
    }

    ports {
      port = 80
      target_port = 8080
    }
  }
}
