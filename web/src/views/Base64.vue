<template>
  <div class="base64">
    <Base64component />
  </div>
</template>

<script>
// @ is an alias to /src
import Base64component from "@/components/Base64component.vue";

export default {
  name: "base64",
  components: {
    Base64component
  }
};
</script>
