import { webAPIUrl } from "./AppSettings";
import authHeader from "./Services/AuthHeader";

export interface HttpRequest<REQB> {
  path: string;
  method?: string;
  body?: REQB;
  accessToken?: string;
}
export interface HttpResponse<RESB> {
  ok: boolean;
  body?: RESB;
}

export const http = async <RESB, REQB = undefined>(
  config: HttpRequest<REQB>
): Promise<HttpResponse<RESB>> => {
  const request = new Request(`${webAPIUrl}${config.path}`, {
    method: config.method || "get",
    headers: {
      "Content-Type": "application/json",
    },
    body: config.body ? JSON.stringify(config.body) : undefined,
  });

  const accessToken = authHeader();
  if (accessToken) {
    request.headers.set("Authorization", `Bearer ${accessToken}`);
  }

  const response = await fetch(request);

  if (response.ok) {
    const body = await response.json();
    return { ok: response.ok, body };
  } else {
    return { ok: response.ok };
  }
};
